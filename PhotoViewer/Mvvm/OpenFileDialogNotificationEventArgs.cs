//-----------------------------------------------------------------------
// <copyright file="OpenFileDialogNotificationEventArgs.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// ファイルを開くダイアログボックス表示の通知用イベント引数を定義します。
    /// </summary>
    internal class OpenFileDialogNotificationEventArgs : InteractionRequestEventArgsBase<OpenFileDialogNotification, string>
    {
    }
}
