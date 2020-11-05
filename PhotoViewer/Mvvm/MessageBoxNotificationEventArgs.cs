//-----------------------------------------------------------------------
// <copyright file="MessageBoxNotificationEventArgs.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using System.Windows;

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// メッセージボックス表示の通知用イベント引数を定義します。
    /// </summary>
    internal class MessageBoxNotificationEventArgs : InteractionRequestEventArgsBase<MessageBoxNotification, MessageBoxResult>
    {
    }
}
