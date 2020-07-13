//-----------------------------------------------------------------------
// <copyright file="TriggerActionBehaviorBase.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Interactivity;

namespace PhotoViewer.View.Behavior
{
    /// <summary>
    /// メッセージの通知内容をメッセージボックスで表示します。
    /// </summary>
    /// <typeparam name="TAssociatedObject">このアクションをアタッチできる型。</typeparam>
    /// <typeparam name="TEventArgs">このアクションへのパラメーターの型。</typeparam>
    internal abstract class TriggerActionBehaviorBase<TAssociatedObject, TEventArgs> : TriggerAction<TAssociatedObject> where TAssociatedObject : DependencyObject where TEventArgs : EventArgs
    {
        /// <summary>
        /// アクションを起動します。
        /// </summary>
        /// <param name="parameter">
        /// アクションへのパラメーター。
        /// アクションがパラメーターを要求しない場合、パラメーターを null 参照に設定できます。
        /// </param>
        protected sealed override void Invoke(object parameter) => Invoke(parameter as TEventArgs);

        /// <summary>
        /// アクションを起動します。
        /// </summary>
        /// <param name="parameter">
        /// アクションへのパラメーター。
        /// アクションがパラメーターを要求しない場合、パラメーターを null 参照に設定できます。
        /// </param>
        protected abstract void Invoke(TEventArgs parameter);
    }
}
