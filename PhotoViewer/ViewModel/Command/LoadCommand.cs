//-----------------------------------------------------------------------
// <copyright file="LoadCommand.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;
using System.Linq;

namespace PhotoViewer.ViewModel.Command
{
    /// <summary>
    /// ロードコマンドを定義します。
    /// </summary>
    internal class LoadCommand : CommandBase<object[]>
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
                string[] args = null;
                MainViewModel mainViewModel = null;

                if (parameter.Length > 0)
                {
                    args = parameter[0] as string[];
                }

                if (parameter.Length > 1)
                {
                    mainViewModel = parameter[1] as MainViewModel;
                }

                if (args != null && mainViewModel != null)
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
                string[] args = null;
                MainViewModel mainViewModel = null;

                if (parameter.Length > 0)
                {
                    args = parameter[0] as string[];
                }

                if (parameter.Length > 1)
                {
                    mainViewModel = parameter[1] as MainViewModel;
                }

                if (args != null && mainViewModel != null)
                {
                    mainViewModel.Load(args.FirstOrDefault());
                }
            }
        }
    }
}
