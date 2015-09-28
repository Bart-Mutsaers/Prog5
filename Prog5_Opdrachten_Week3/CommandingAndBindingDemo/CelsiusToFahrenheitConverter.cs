using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CommandingAndBindingDemo {
  class CelsiusToFahrenheitConverter : IValueConverter {

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
       return (double)value * 1.80 + 32;
           }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
      // maar één kant op
      return value;
    }
  }
}
