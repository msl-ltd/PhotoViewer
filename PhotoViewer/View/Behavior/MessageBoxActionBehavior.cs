//-----------------------------------------------------------------------
// <copyright file="MessageBoxActionBehavior.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;
using System.Windows;

namespace PhotoViewer.View.Behavior
{
    /// <summary>
    /// メッセージの通知内容をメッセージボックスで表示します。
    /// </summary>
    internal class MessageBoxActionBehavior : TriggerActionBehaviorBase<DependencyObject, MessageBoxNotificationEventArgs>
    {
        /// <summary>
        /// アクションを起動します。
        /// </summary>
        /// <param name="parameter">
        /// アクションへのパラメーター。
        /// アクションがパラメーターを要求しない場合、パラメーターを null 参照に設定できます。
        /// </param>
        protected override void Invoke(MessageBoxNotificationEventArgs parameter)
        {
            if (parameter != null)
            {
                var content = parameter.Content;
                var result = MessageBox.Show(Window.GetWindow(AssociatedObject), content.Text, content.Caption, content.Button, content.Icon);
                parameter.Callback?.Invoke(result);
            }
        }
    }
}
