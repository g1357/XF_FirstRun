using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XF_FirstRun.Helpers
{
    /// <summary>
    /// Конвертор (преобразователь) логических значейний (bool) в строки "true" и "false" соответственно
    /// и обратно.
    /// </summary>
    /// <remarks>
    /// При обратном преобразовании значение "true" (любыми буквами) преобразуется в "истину" 
    /// все остальные значения в "ложь".
    /// </remarks>
    public class BoolToStringConverter : IValueConverter
    {
        /// <summary>
        /// Преобразовывает логическое значение типа bool в строковое значение "true" или "false"
        /// </summary>
        /// <param name="value">Преобразовываемое значение</param>
        /// <param name="targetType">не используется</param>
        /// <param name="parameter">не используется</param>
        /// <param name="culture">не используется</param>
        /// <returns>Строка "true" или "false" в зависимости от значения value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "true" : "false";
        }

        /// <summary>
        /// Преобразует строку "true" (любыми буквами) в логическое (bool) значение "истина",
        /// все остальные строки в значение "ложь"
        /// </summary>
        /// <param name="value">Преобразовываемое значение</param>
        /// <param name="targetType">не используется<</param>
        /// <param name="parameter">не используется<</param>
        /// <param name="culture">не используется<</param>
        /// <returns>Логическое (bool) значение в зависимости от значения value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).ToLower() == "true";
        }
    }
}
