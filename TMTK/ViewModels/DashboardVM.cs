using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace TMTK
{
	public class DashboardVM : ViewModelBase
	{
		private Menu _selectedMenu;

		public DashboardVM()
		{
			//MenusCategories = new List<MenuCategory>(MenusDefinition.MenusCategories.Values);
			AllMenus = MenusDefinition.AllMenus.Where((arg) => arg.IsMenu == false).ToList();

			//MenusGroupedByCategory = MenusDefinition.MenusGroupedByCategory;
		}

		public List<MenuCategory> MenusCategories { get; set; }

		public List<Menu> AllMenus { get; set; }

		public List<MenuGroup> MenusGroupedByCategory { get; set; }

		public Menu SelectedMenu
		{
			get
			{
				return _selectedMenu;
			}

			set
			{
				if (value != _selectedMenu)
				{
					_selectedMenu = value;
					OnPropertyChanged("SelectedMenu");
				}
			}
		}
	}
}
