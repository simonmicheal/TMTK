using System;
using Xamarin.Forms;

namespace TMTK
{
	public class DatetimetoStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
				return string.Empty;

			DateTimeOffset dto = DateTimeOffset.Parse(value.ToString());
			//Get the date object from the string. 
			DateTime dtObject = dto.DateTime;
			return dtObject.ToLocalTime().ToString("f");
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
