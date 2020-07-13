//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Model;
using PhotoViewer.Mvvm;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace PhotoViewer.ViewModel
{
    /// <summary>
    /// メインビューモデルを定義します。
    /// </summary>
    internal class MainViewModel : BindableBase
    {
        /// <summary>
        /// モデルを保持します。
        /// </summary>
        private readonly MainModel _mainModel;

        /// <summary>
        /// PhotoViewer.ViewModel.MainViewModel クラスの新しいインスタンスを初期化します。
        /// </summary>
        public MainViewModel()
        {
            _mainModel = new MainModel();
            _mainModel.PropertyChanged += MainModel_PropertyChanged;
            _mainModel.PropertyChanged += MainViewModel_PropertyChanged;

            OpenFileDialogRequest = new InteractionRequest<OpenFileDialogNotificationEventArgs>();
            MessageBoxRequest = new InteractionRequest<MessageBoxNotificationEventArgs>();
        }

        /// <summary>
        /// PhotoViewer.ViewModel.MainViewModel クラスの新しいインスタンスを解放します。
        /// </summary>
        ~MainViewModel()
        {
            _mainModel.PropertyChanged -= MainModel_PropertyChanged;
            _mainModel.PropertyChanged -= MainViewModel_PropertyChanged;
        }

        /// <summary>
        /// バージョン情報を取得します。
        /// </summary>
        public FileVersionInfo FileVersionInfo => _mainModel.FileVersionInfo;

        /// <summary>
        /// 読み込み可能なファイルのパターンを取得します。
        /// </summary>
        public string[] ReadableFiles => _mainModel.ReadableFiles;

        /// <summary>
        /// ファイル名を取得します。
        /// </summary>
        public string FileName => _mainModel.FileName;

        /// <summary>
        /// 画像を取得します。
        /// </summary>
        public BitmapFrame Source => _mainModel.Source;

        /// <summary>
        ///  画像のメタデータを取得します。
        /// </summary>
        public BitmapMetadata Metadata => _mainModel.Metadata;

        /// <summary>
        /// 回転情報を取得します。
        /// </summary>
        public ushort? Orientation => _mainModel.Orientation;

        /// <summary>
        /// ファイルが存在するかを取得します。
        /// </summary>
        public bool IsExist => _mainModel.IsExist;

        /// <summary>
        /// 他のファイルが存在するかを取得します。
        /// </summary>
        public bool IsExistOther => _mainModel.IsExistOther;

        /// <summary>
        /// タイトルを取得します。
        /// </summary>
        public string Title
        {
            get
            {
                var productName = FileVersionInfo.ProductName;
                if (!string.IsNullOrEmpty(FileName))
                {
                    productName = $"{productName} - {FileName}";
                }

                return productName;
            }
        }

        /// <summary>
        /// ファイルを開くダイアログボックス表示リクエストを取得または設定します。
        /// </summary>
        public InteractionRequest<OpenFileDialogNotificationEventArgs> OpenFileDialogRequest
        {
            get;
            private set;
        }

        /// <summary>
        /// メッセージボックス表示リクエストを取得または設定します。
        /// </summary>
        public InteractionRequest<MessageBoxNotificationEventArgs> MessageBoxRequest
        {
            get;
            private set;
        }

        /// <summary>
        /// ファイルを読み込みます。
        /// </summary>
        /// <param name="fileName">ファイル名。</param>
        public void Load(string fileName) => _mainModel.Load(fileName);

        /// <summary>
        /// 前のファイルを読み込みます。
        /// </summary>
        public void Previous() => _mainModel.Previous();

        /// <summary>
        /// 次のファイルを読み込みます。
        /// </summary>
        public void Next() => _mainModel.Next();

        /// <summary>
        /// ファイルをコピーします。
        /// </summary>
        public void Copy() => _mainModel.Copy();

        /// <summary>
        /// ファイルを削除します。
        /// </summary>
        public void Delete() => _mainModel.Delete();

        /// <summary>
        /// メインモデルのプロパティの変更を通知します。
        /// </summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントのデータ。</param>
        private void MainModel_PropertyChanged(object sender, PropertyChangedEventArgs e) => RaisePropertyChanged(e?.PropertyName);

        /// <summary>
        /// メインビューモデルのプロパティの変更を通知します。
        /// </summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントのデータ。</param>
        private void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // メインビューモデルのプロパティの変更を通知します。
            switch (e?.PropertyName)
            {
                case nameof(FileName):
                    RaisePropertyChanged(nameof(Title));
                    break;

                default:
                    break;
            }
        }
    }
}
