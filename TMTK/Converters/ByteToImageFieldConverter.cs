using System;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TMTK
{
	public class ByteToImageFieldConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			ImageSource retSource = null;

			try
			{
				if (value != null)
				{
					string convert = value.ToString().Replace("data:image/png;base64,", String.Empty);
					var imageBytes = System.Convert.FromBase64String(convert);

        // Return a new ImageSource
        	return ImageSource.FromStream (() => {return new MemoryStream(imageBytes);});
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return retSource;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
