using System;
using System.Globalization;
using System.Windows.Data;
using System.Collections.Generic;
using PriceListEditor.Interfaces;
using System.Windows.Controls;

namespace PriceListEditor.Classes.Converters
{
    public class LoadedModuleToRadioButtonConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            IEnumerable<ILoadableModule> modules = value as IEnumerable<ILoadableModule>;
            List<RadioButton> result = new List<RadioButton>();

            if (modules != null)
            {
                foreach (ILoadableModule module in modules)
                {
                    result.Add(new RadioButton() { Content = new String[] { module.IconCharacter, module.ModuleName } } );
                }
            }

            return result;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
