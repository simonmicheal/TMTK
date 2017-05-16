using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TMTK
{
	public class MenuCategory
	{
		public string Name { get; set; }

		public Color BackgroundColor { get; set; }

	//	public String BackgroundImage { get; set; }

		public List<Menu> MenuList { get; set; }

		public char Icon { get; set; }
	}
}