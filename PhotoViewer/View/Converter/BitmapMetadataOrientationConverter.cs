//-----------------------------------------------------------------------
// <copyright file="BitmapMetadataOrientationConverter.cs" company="MSL Ltd.">
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
    /// 画像の回転情報を時計回りの角度へ変換します。
    /// </summary>
    internal class BitmapMetadataOrientationConverter : IValueConverter
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
            int angle = 0;

            if (value != null)
            {
                var orientation = System.Convert.ChangeType(value, typeof(int));
                switch (orientation)
                {
                    case 1:
                    case 2:
                        angle = 0;
                        break;

                    case 3:
                    case 4:
                        angle = 180;
                        break;

                    case 5:
                    case 6:
                        angle = 90;
                        break;

                    case 7:
                    case 8:
                        angle = 270;
                        break;
                }
            }

            return System.Convert.ChangeType(angle, targetType);
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
