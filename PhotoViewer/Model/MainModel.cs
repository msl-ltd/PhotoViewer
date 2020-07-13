//-----------------------------------------------------------------------
// <copyright file="MainModel.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using Microsoft.VisualBasic.FileIO;
using PhotoViewer.Mvvm;
using PhotoViewer.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PhotoViewer.Model
{
    /// <summary>
    /// メインモデルを定義します。
    /// </summary>
    internal class MainModel : BindableBase
    {
        /// <summary>
        /// ファイル名を保持します。
        /// </summary>
        private string _fileName;

        /// <summary>
        /// 画像を保持します。
        /// </summary>
        private BitmapFrame _source;

        /// <summary>
        /// メタデータを保持します。
        /// </summary>
        private BitmapMetadata _metadata;

        /// <summary>
        /// 回転情報を保持します。
        /// </summary>
        private ushort? _orientation;

        /// <summary>
        /// バージョン情報を取得します。
        /// </summary>
        public FileVersionInfo FileVersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

        /// <summary>
        /// 読み込み可能なファイルのパターンを取得します。
        /// </summary>
        public string[] ReadableFiles => Resources.FILE_FILTER.Split('|').Where((arg1, arg2) => (arg2 % 2) == 1).SelectMany(arg => arg.Split(';')).Where(arg => !"*.*".Equals(arg)).ToArray();

        /// <summary>
        /// ファイル名を取得または設定します。
        /// </summary>
        public string FileName
        {
            get => _fileName;
            private set => SetProperty(ref _fileName, value, nameof(FileName));
        }

        /// <summary>
        /// 画像を取得または設定します。
        /// </summary>
        public BitmapFrame Source
        {
            get => _source;
            private set => SetProperty(ref _source, value, nameof(Source));
        }

        /// <summary>
        ///  メタデータを取得または設定します。
        /// </summary>
        public BitmapMetadata Metadata
        {
            get => _metadata;
            private set => SetProperty(ref _metadata, value, nameof(Metadata));
        }

        /// <summary>
        /// 回転情報を取得または設定します。
        /// </summary>
        public ushort? Orientation
        {
            get => _orientation;
            private set => SetProperty(ref _orientation, value, nameof(Orientation));
        }

        /// <summary>
        /// ファイルが存在するかを取得します。
        /// </summary>
        public bool IsExist => File.Exists(FileName);

        /// <summary>
        /// 他のファイルが存在するかを取得します。
        /// </summary>
        public bool IsExistOther => GetReadableFiles().Any(arg => string.Compare(FileName, arg, true) != 0);

        /// <summary>
        /// ファイルを読み込みます。
        /// </summary>
        /// <param name="fileName">ファイル名。</param>
        public void Load(string fileName)
        {
            BitmapFrame bitmapFrame = null;

            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    bitmapFrame = BitmapFrame.Create(new Uri(fileName), BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.OnLoad);
                }
            }
            finally
            {
                FileName = fileName;

                Source = bitmapFrame;
                Metadata = Source?.Metadata as BitmapMetadata;
                Orientation = Metadata?.GetQuery(@"/app1/ifd/{ushort=274}") as ushort?;
            }
        }

        /// <summary>
        /// 前のファイルを読み込みます。
        /// </summary>
        public void Previous()
        {
            var files = GetReadableFiles();
            if (files.Length > 0)
            {
                var file = Array.FindLast(files, arg => string.Compare(FileName, arg, true) > 0);
                Load(file ?? files.Last());
            }
        }

        /// <summary>
        /// 次のファイルを読み込みます。
        /// </summary>
        public void Next()
        {
            var files = GetReadableFiles();
            if (files.Length > 0)
            {
                var file = Array.Find(files, arg => string.Compare(FileName, arg, true) < 0);
                Load(file ?? files.First());
            }
        }

        /// <summary>
        /// ファイルをコピーします。
        /// </summary>
        public void Copy()
        {
            if (IsExist)
            {
                Clipboard.SetFileDropList(new StringCollection
                {
                    FileName
                });
            }
        }

        /// <summary>
        /// ファイルを削除します。
        /// </summary>
        public void Delete()
        {
            if (IsExist)
            {
                FileSystem.DeleteFile(FileName, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
            }
        }

        /// <summary>
        /// 読み込み可能なファイルの一覧を取得します。
        /// </summary>
        /// <returns>ファイル一覧。</returns>
        private string[] GetReadableFiles()
        {
            var files = new List<string>();

            if (!string.IsNullOrEmpty(FileName))
            {
                var path = Path.GetDirectoryName(FileName);
                files.AddRange(ReadableFiles.SelectMany(arg => Directory.GetFiles(path, arg)));
                files.Sort();
            }

            return files.ToArray();
        }
    }
}
