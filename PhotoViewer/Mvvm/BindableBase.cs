//-----------------------------------------------------------------------
// <copyright file="BindableBase.cs" company="MSL Ltd.">
//      (C) 2018 MSL Ltd.
// </copyright>
// <author>Miyata Tomoyuki</author>
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel;

namespace PhotoViewer.Mvvm
{
    /// <summary>
    /// BindableBaseを定義します。
    /// </summary>
    internal class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティ値が変更するときに発生します。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティ変更イベントを発生します。
        /// </summary>
        /// <param name="propertyName">変更したプロパティ名。</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// プロパティを変更します。
        /// </summary>
        /// <typeparam name="T">変更するプロパティの型。</typeparam>
        /// <param name="field">変更するプロパティ。</param>
        /// <param name="value">変更する値。</param>
        /// <param name="propertyName">変更するプロパティ名。</param>
        protected void SetProperty<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
            }
        }
    }
}
