using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PriceListEditor.Classes.Converters
{
    public class StringListToStringConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<String>)
            {
                IEnumerable<String> stringList = value as IEnumerable<String>;
                StringBuilder result = new StringBuilder();
                foreach (String str in stringList)
                {
                    result.AppendLine(str);
                }
                return result.ToString();
            }
            else
            {
                return value.ToString();
            }
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            if (value is String)
            {
                String inStr = value as String;
                List<String> result = new List<String>(Regex.Split(inStr, Environment.NewLine));
                return result;
            }
            else
            {
                return new List<String>() { value.ToString() };
            }
        }
    }
}
