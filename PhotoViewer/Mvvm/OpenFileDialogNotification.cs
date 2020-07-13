//-----------------------------------------------------------------------
// <copyright file="OpenFileDialogNotification.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// ファイルを開くダイアログボックス表示の通知内容を定義します。
    /// </summary>
    internal class OpenFileDialogNotification
    {
        /// <summary>
        /// ファイルの種類を決定するフィルター文字列を取得または設定します。
        /// </summary>
        public string Filter
        {
            get;
            set;
        }
    }
}
