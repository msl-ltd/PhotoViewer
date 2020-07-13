//-----------------------------------------------------------------------
// <copyright file="InteractionRequest.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using System;

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// 通知を定義します。
    /// </summary>
    /// <typeparam name="T">通知イベント用のイベント引数の型。</typeparam>
    internal class InteractionRequest<T> where T : EventArgs
    {
        /// <summary>
        /// 通知したときに発生します。
        /// </summary>
        public event EventHandler<T> Notified;

        /// <summary>
        /// 通知イベントを発生します。
        /// </summary>
        /// <param name="notificationEventArgs">通知の内容。</param>
        public void Raise(T notificationEventArgs)
        {
            if (notificationEventArgs != null)
            {
                Notified?.Invoke(this, notificationEventArgs);
            }
        }
    }
}
