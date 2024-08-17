//-----------------------------------------------------------------------
// <copyright file="EventToCommandActionBehavior.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace PhotoViewer.View.Behavior
{
    /// <summary>
    /// イベントのパラメーターをコマンドパラメーターへ設定してコマンドを実行します。
    /// </summary>
    internal class EventToCommandActionBehavior : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// コマンドを保持します。
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommandActionBehavior));

        /// <summary>
        /// コマンドパラメーターを保持します。
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventToCommandActionBehavior));

        /// <summary>
        /// コマンドを取得または設定します。
        /// </summary>
        public ICommand Command
        {
            get => GetValue(CommandProperty) as ICommand;
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        /// コマンドパラメーターを取得または設定します。
        /// </summary>
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// アクションを起動します。
        /// </summary>
        /// <param name="parameter">
        /// アクションへのパラメーター。
        /// アクションがパラメーターを要求しない場合、パラメーターを null 参照に設定できます。
        /// </param>
        protected override void Invoke(object parameter)
        {
            if (Command != null)
            {
                var argument = parameter;
                if (CommandParameter != null)
                {
                    argument = new object[] { parameter, CommandParameter };
                }

                if (Command.CanExecute(argument))
                {
                    try
                    {
                        Command.Execute(argument);
                    }
                    finally
                    {
                        CommandManager.InvalidateRequerySuggested();
                    }
                }
            }
        }
    }
}
