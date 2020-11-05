//-----------------------------------------------------------------------
// <copyright file="BitmapMetadataConverter.cs" company="MSL Ltd.">
//     (C) 2018 MSL Ltd.
// </copyright>
// <author>MIYATA Tomoyuki</author>
//-----------------------------------------------------------------------
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotoViewer.View.Converter
{
    /// <summary>
    /// メタデータを変換します。
    /// </summary>
    internal class BitmapMetadataConverter : IValueConverter
    {
        /// <summary>
        /// 値を変換します。
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値。</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>変換された値。 メソッドが null を返す場合は、正しい null 値が使用されます。</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;

            if (value is BitmapMetadata bitmapMetadata && parameter is string query)
            {
                result = bitmapMetadata.GetQuery(query);
                switch (result)
                {
                    case Int64 n:
                        {
                            // 分子
                            var numerator = (Int32)(n & 0xffffffff);

                            // 分母
                            var denominator = (Int32)(n >> 32);

                            if (numerator < denominator)
                            {
                                // 1より小さい場合は、ユークリッドの互除法により最大公約数を求めます。
                                var a = denominator;
                                var b = numerator;
                                while (b != 0)
                                {
                                    var r = a % b;
                                    a = b;
                                    b = r;
                                }

                                result = $"{numerator / a}/{denominator / a}";
                            }
                            else
                            {
                                // 1または1より大きい
                                result = (double)numerator / denominator;
                            }
                        }

                        break;

                    case UInt64 n:
                        {
                            // 分子
                            var numerator = (UInt32)(n & 0xffffffff);

                            // 分母
                            var denominator = (UInt32)(n >> 32);

                            if (numerator < denominator)
                            {
                                // 1より小さい場合は、ユークリッドの互除法により最大公約数を求めます。
                                var a = denominator;
                                var b = numerator;
                                while (b != 0)
                                {
                                    var r = a % b;
                                    a = b;
                                    b = r;
                                }

                                result = $"{numerator / a}/{denominator / a}";
                            }
                            else
                            {
                                // 1または1より大きい
                                result = (double)numerator / denominator;
                            }
                        }

                        break;

                    default:
                        break;
                }
            }

            return System.Convert.ChangeType(result, targetType);
        }

        /// <summary>
        /// 値を変換します。
        /// </summary>
        /// <param name="value">バインディング ターゲットによって生成された値。</param>
        /// <param name="targetType">変換後の型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>変換された値。 メソッドが null を返す場合は、正しい null 値が使用されます。</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
