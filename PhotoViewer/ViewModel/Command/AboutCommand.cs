//-----------------------------------------------------------------------
// <copyright file="AboutCommand.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;
using PhotoViewer.Properties;
using System;
using System.Windows;

namespace PhotoViewer.ViewModel.Command
{
    /// <summary>
    /// アプリケーションについてコマンドを定義します。
    /// </summary>
    internal class AboutCommand : CommandBase<MainViewModel>
    {
        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        protected override bool CanExecute(MainViewModel parameter) => parameter != null;

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        protected override void Execute(MainViewModel parameter)
        {
            if (parameter != null)
            {
                var fileVersionInfo = parameter.FileVersionInfo;
                var messageBoxNotification = new MessageBoxNotification()
                {
                    Text = $"{fileVersionInfo.ProductName}{Environment.NewLine}{Resources.FILE_VERSION} {fileVersionInfo.ProductVersion}{Environment.NewLine}{fileVersionInfo.LegalCopyright}",
                    Caption = Resources.CAPTION_ABOUT,
                    Button = MessageBoxButton.OK,
                    Icon = MessageBoxImage.Information,
                };
                var messageBoxNotificationEventArgs = new MessageBoxNotificationEventArgs()
                {
                    Content = messageBoxNotification,
                };

                parameter.MessageBoxRequest.Raise(messageBoxNotificationEventArgs);
            }
        }
    }
}
