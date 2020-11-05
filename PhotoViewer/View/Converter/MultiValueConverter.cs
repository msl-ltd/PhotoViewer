//-----------------------------------------------------------------------
// <copyright file="MultiValueConverter.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using System;
using System.Globalization;
using System.Windows.Data;

namespace PhotoViewer.View.Converter
{
    /// <summary>
    /// 複数のコマンドパラメータを単一へ変換します。
    /// </summary>
    internal class MultiValueConverter : IMultiValueConverter
    {
        /// <summary>
        /// ソース値をバインディング ターゲットの値に変換します。
        /// データ バインディング エンジンでは、ソース バインディングからの値をバインディング ターゲットに伝達するときに、このメソッドを呼び出します。
        /// </summary>
        /// <param name="values">
        /// System.Windows.Data.MultiBinding 内のソース バインディングが生成する値の配列。
        /// 値の System.Windows.DependencyProperty.UnsetValueは、変換に提供する値がソース バインディングにないことを示します。
        /// </param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>
        /// 変換された値。メソッドから null が返された場合、有効な null 値が使用されます。戻り値の System.Windows.DependencyProperty.System.Windows.DependencyProperty.UnsetValue
        /// は、コンバーターで値を生成しなかったこと、および System.Windows.Data.BindingBase.FallbackValue が使用できる場合にバインディングでそれを使用し、使用できない場合は既定値を使用することを示します。
        /// 戻り値の System.Windows.Data.Binding.System.Windows.Data.Binding.DoNothing は、バインディングで値を転送しないこと、あるいは
        /// System.Windows.Data.BindingBase.FallbackValue または既定値を使用しないことを示します。
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values?.Clone();

        /// <summary>
        /// バインディング ターゲットの値をバインディング ソースの値に変換します。
        /// </summary>
        /// <param name="value">バインディング ターゲットによって生成される値。</param>
        /// <param name="targetTypes">変換対象の型の配列。 配列の長さは、メソッドの戻り値として推奨されている値の数と型を示します。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>ターゲット値からソース値に変換された値の配列。</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => (value as object[])?.Clone() as object[];
    }
}
