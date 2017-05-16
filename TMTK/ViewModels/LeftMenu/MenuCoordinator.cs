using System;

namespace TMTK
{
	public class MenuCoordinator
	{
		public static event EventHandler<MenuEventArgs> SelectedMenuChanged;
		public static event EventHandler<EventArgs> PresentMainMenuOnAppearance;
		public static event EventHandler<MenuEventArgs> MenuSelected;

		private static Menu _selectedMenu = null;

		public static void RaisePresentMainMenuOnAppearance()
		{
			if (PresentMainMenuOnAppearance != null)
			{
				PresentMainMenuOnAppearance(typeof(MenuCoordinator), null);
			}
		}

		public static void RaiseMenuSelected(Menu sample)
		{
			if (MenuSelected != null)
			{
				MenuSelected(typeof(MenuCoordinator), new MenuEventArgs(sample));
			}
		}

		public static Menu SelectedMenu
		{
			get
			{
				return _selectedMenu;
			}

			set
			{
				if (_selectedMenu != value)
				{
					_selectedMenu = value;

					if (SelectedMenuChanged != null)
					{
						SelectedMenuChanged(typeof(MenuCoordinator), new MenuEventArgs(value));
					}
				}
			}
		}
	}

	public class MenuEventArgs : EventArgs
	{
		private readonly Menu _sample;

		public MenuEventArgs(Menu newMenu)
		{
			_sample = newMenu;
		}

		public Menu Menu
		{
			get
			{
				return _sample;
			}
		}
	}
}
