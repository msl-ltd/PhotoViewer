//-----------------------------------------------------------------------
// <copyright file="InteractionRequestEventArgsBase.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using System;

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// 通知イベント用のイベント引数を定義します。
    /// </summary>
    /// <typeparam name="TContent">通知内容の型。</typeparam>
    /// <typeparam name="TCallbackArgs">通知結果コールバックのパラメーターの型。</typeparam>
    internal class InteractionRequestEventArgsBase<TContent, TCallbackArgs> : EventArgs
    {
        /// <summary>
        /// 通知内容を取得または設定します。
        /// </summary>
        public TContent Content
        {
            get;
            set;
        }

        /// <summary>
        /// 結果通知コールバックを取得または設定します。
        /// </summary>
        public Action<TCallbackArgs> Callback
        {
            get;
            set;
        }
    }
}
