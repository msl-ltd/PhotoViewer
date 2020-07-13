//-----------------------------------------------------------------------
// <copyright file="PreviousCommand.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;

namespace PhotoViewer.ViewModel.Command
{
    /// <summary>
    /// 前へコマンドを定義します。
    /// </summary>
    internal class PreviousCommand : CommandBase<MainViewModel>
    {
        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        protected override bool CanExecute(MainViewModel parameter)
        {
            bool can = false;

            if (parameter != null)
            {
                if (parameter.IsExistOther)
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
        protected override void Execute(MainViewModel parameter)
        {
            if (parameter != null)
            {
                parameter.Previous();
            }
        }
    }
}
