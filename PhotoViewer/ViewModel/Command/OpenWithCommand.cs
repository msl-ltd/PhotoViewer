//-----------------------------------------------------------------------
// <copyright file="OpenWithCommand.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;
using System.Diagnostics;

namespace PhotoViewer.ViewModel.Command
{
    /// <summary>
    /// プログラムから開くコマンドを定義します。
    /// </summary>
    internal class OpenWithCommand : CommandBase<string>
    {
        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        protected override bool CanExecute(string parameter) => !string.IsNullOrEmpty(parameter);

        /// <summary>
        /// コマンドが起動される際に呼び出すメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        protected override void Execute(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                using (var process = Process.Start(parameter))
                {
                }
            }
        }
    }
}
