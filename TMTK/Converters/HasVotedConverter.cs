using System;
using TMTK.Models;
using Xamarin.Forms;

namespace TMTK
{
	public class HasVotedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
				return Color.Red;

			var con = (ContestVote)value;

			if (con != null)
			{
				if (con.FinalistId != "")
				{
					return Color.Gray;
				}
				else
				{
					return Color.Red;
				}
			}

			return Color.Red;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}