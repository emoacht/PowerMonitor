using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PowerTracker.Views.Converters
{
	[ValueConversion(typeof(DateTimeOffset), typeof(string))]
	public class TimeConverter : IValueConverter
	{
		public int Interval { get; set; } = 5;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is DateTimeOffset))
				return DependencyProperty.UnsetValue;

			var time = (DateTimeOffset)value;
			var timing = (time.Minute * 60 + time.Second) % (Interval * 60);

			return $"{time:HH:mm:ss} [{timing}]";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}