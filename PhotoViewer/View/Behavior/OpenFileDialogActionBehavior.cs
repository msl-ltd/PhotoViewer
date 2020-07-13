//-----------------------------------------------------------------------
// <copyright file="OpenFileDialogActionBehavior.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using Microsoft.Win32;
using PhotoViewer.Mvvm;
using System.Windows;

namespace PhotoViewer.View.Behavior
{
    /// <summary>
    /// ファイルを開くダイアログボックスを表示します。
    /// </summary>
    internal class OpenFileDialogActionBehavior : TriggerActionBehaviorBase<DependencyObject, OpenFileDialogNotificationEventArgs>
    {
        /// <summary>
        /// アクションを起動します。
        /// </summary>
        /// <param name="parameter">
        /// アクションへのパラメーター。
        /// アクションがパラメーターを要求しない場合、パラメーターを null 参照に設定できます。
        /// </param>
        protected override void Invoke(OpenFileDialogNotificationEventArgs parameter)
        {
            if (parameter != null)
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = parameter.Content.Filter,
                };
                if (openFileDialog.ShowDialog(Window.GetWindow(AssociatedObject)) == true)
                {
                    parameter.Callback?.Invoke(openFileDialog.FileName);
                }
            }
        }
    }
}
