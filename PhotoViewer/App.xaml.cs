//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace PhotoViewer
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// コマンドライン引数を取得または設定します。
        /// </summary>
        public List<string> Args
        {
            get;
            private set;
        }

        /// <summary>
        /// OnStartup イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントのデータ。</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // 例外捕捉ハンドラを登録します。
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // コマンドライン引数を設定します。
            if (e != null)
            {
                Args = new List<string>(e.Args);
            }

            base.OnStartup(e);
        }

        /// <summary>
        /// Exit イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントのデータ。</param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            // 例外捕捉ハンドラを削除します。
            AppDomain.CurrentDomain.UnhandledException -= CurrentDomain_UnhandledException;
            DispatcherUnhandledException -= App_DispatcherUnhandledException;
        }

        /// <summary>
        /// メインスレッドで発生した未処理例外を捕捉します。
        /// </summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントのデータ。</param>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var messageBoxText = string.Empty;
            if (e != null)
            {
                messageBoxText = $"{e.Exception.Message}{Environment.NewLine}({e.Exception.GetType()}){Environment.NewLine}{e.Exception.StackTrace}";

                e.Handled = true;
            }

            MessageBox.Show(Current.MainWindow, messageBoxText, PhotoViewer.Properties.Resources.CAPTION_ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// サブスレッドで発生した未処理例外を捕捉します。
        /// </summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントのデータ。</param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var messageBoxText = string.Empty;
            if (e.ExceptionObject is Exception ex)
            {
                messageBoxText = $"{ex.Message}{Environment.NewLine}({ex.GetType()}){Environment.NewLine}{ex.StackTrace}";
            }

            MessageBox.Show(Current.MainWindow, messageBoxText, PhotoViewer.Properties.Resources.CAPTION_ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
