using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;

namespace TMTK
{
	public class MainMenuViewModel : ViewModelBase
	{
		private Menu _selectedMenu;

		public MainMenuViewModel(INavigation navigation)
		{
			//MenusCategories = new List<MenuCategory>(MenusDefinition.MenusCategories.Values);
			//AllMenus = MenusDefinition.AllMenus.Where((arg) => arg.IsMenu == true).ToList();
			MenusGroupedByCategory = MenusDefinition.MenusGroupedByCategory.Skip(1).ToList();
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