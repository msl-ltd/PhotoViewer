//-----------------------------------------------------------------------
// <copyright file="DropCommand.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;
using System.Linq;
using System.Windows;

namespace PhotoViewer.ViewModel.Command
{
    /// <summary>
    /// ドロップコマンドを定義します。
    /// </summary>
    internal class DropCommand : CommandBase<object[]>
    {
        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        protected override bool CanExecute(object[] parameter)
        {
            bool can = false;

            if (parameter != null)
            {
                DragEventArgs dragEventArgs = null;
                MainViewModel mainViewModel = null;

                if (parameter.Length > 0)
                {
                    dragEventArgs = parameter[0] as DragEventArgs;
                }

                if (parameter.Length > 1)
                {
                    mainViewModel = parameter[1] as MainViewModel;
                }

                if (dragEventArgs != null && mainViewModel != null)
                {
                    can = true;
                }
            }

            return can;
        }

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        protected override void Execute(object[] parameter)
        {
            if (parameter != null)
            {
                DragEventArgs dragEventArgs = parameter[0] as DragEventArgs;
                MainViewModel mainViewModel = parameter[1] as MainViewModel;

                if (dragEventArgs.Data.GetData(DataFormats.FileDrop) is string[] files)
                {
                    mainViewModel.Load(files.FirstOrDefault());
                }
            }
        }
    }
}
