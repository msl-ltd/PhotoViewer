//-----------------------------------------------------------------------
// <copyright file="MessageBoxNotification.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using System.Windows;

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// メッセージボックス表示の通知内容を定義します。
    /// </summary>
    internal class MessageBoxNotification
    {
        /// <summary>
        /// 表示するテキストを取得または設定します。
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// 表示するタイトル バーのキャプションを取得または設定します。
        /// </summary>
        public string Caption
        {
            get;
            set;
        }

        /// <summary>
        /// 表示するボタンを取得または設定します。
        /// </summary>
        public MessageBoxButton Button
        {
            get;
            set;
        }

        /// <summary>
        /// 表示するアイコンを取得または設定します。
        /// </summary>
        public MessageBoxImage Icon
        {
            get;
            set;
        }
    }
}
