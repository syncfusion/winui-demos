#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Syncfusion.DemosCommon.WinUI
{
    /// <summary>
    /// A markup extension that returns a collection of values of a specific <see langword="enum"/>
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(List<string>))]
    public sealed class EnumToStringValuesExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the <see cref="System.Type"/> of the target <see langword="enum"/>
        /// </summary>
        public Type Type { get; set; }

        /// <inheritdoc/>
        protected override object ProvideValue()
        {
            var values = new List<string>();
            foreach (var item in Enum.GetValues(Type))
            {
                if (!values.Contains(item.ToString()))
                {
                    values.Add(item.ToString());
                }
            }

            return values;
        }
    }

    /// <summary>
    /// A Converter class that helps to return enum or string value
    /// </summary>
    public class StringToEnumValueConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        /// Gets or sets the a value indicating whether return string or enum
        /// </summary>
        public bool IsInversed { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.Type"/> of the target <see langword="enum"/>
        /// </summary>
        public Type Type { get; set; }

        /// <inheritdoc/>
        protected override object ProvideValue()
        {
            return this;
        }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (IsInversed)
            {
                if (Enum.TryParse(Type, value?.ToString(), out object result))
                {
                    return result;
                }
            }

            return value?.ToString();
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (IsInversed)
            {
                return value;
            }
            else if (Enum.TryParse(Type, value?.ToString(), out object result))
            {
                return result;
            }

            return value;
        }
    }

}
