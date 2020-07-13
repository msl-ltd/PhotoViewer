//-----------------------------------------------------------------------
// <copyright file="OpenCommand.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using PhotoViewer.Mvvm;
using PhotoViewer.Properties;

namespace PhotoViewer.ViewModel.Command
{
    /// <summary>
    /// オープンコマンドを定義します。
    /// </summary>
    internal class OpenCommand : CommandBase<MainViewModel>
    {
        /// <summary>
        /// 現在の状態でコマンドが実行可能かどうかを決定するメソッドを定義します。
        /// </summary>
        /// <param name="parameter">
        /// コマンドにより使用されるデータです。
        /// コマンドにデータを渡す必要がない場合は、このオブジェクトを null に設定できます。
        /// </param>
        /// <returns>このコマンドを実行できる場合は、true。それ以外の場合は、false。</returns>
        protected override bool CanExecute(MainViewModel parameter) => parameter != null;

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
                var openFileDialogNotification = new OpenFileDialogNotification()
                {
                    Filter = Resources.FILE_FILTER,
                };
                var openFileDialogNotificationEventArgs = new OpenFileDialogNotificationEventArgs()
                {
                    Content = openFileDialogNotification,
                    Callback = fileName => parameter.Load(fileName),
                };

                parameter.OpenFileDialogRequest.Raise(openFileDialogNotificationEventArgs);
            }
        }
    }
}
