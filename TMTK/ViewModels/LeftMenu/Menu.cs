using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TMTK
{
	public class Menu
	{
		private readonly bool _isMenu;
		private readonly string _name;
		private readonly bool _modal;
		private readonly char _icon;
		private readonly Type _pageType;
		private readonly string _backgroundImage;
		private readonly Color _backgroundColor;
		private readonly bool _justNotifyNavigateIntent;
		private readonly Action<INavigation> _customNavigation;
		private readonly PageActions _pageAction;

		public Menu(PageActions pageAction,bool IsMenu, Color backgroundColor, string name, Type pageType, string backgroundImage, char icon = '\uf054', bool modal = false, bool justNotifyNavigateIntent = false, Action<INavigation> customNavigation = null)
		{
			_isMenu = IsMenu;
			_name = name;
			_pageType = pageType;
			_backgroundColor = backgroundColor;
			_icon = icon;
			_backgroundImage = backgroundImage;
			_modal = modal;
			_justNotifyNavigateIntent = justNotifyNavigateIntent;
			_customNavigation = customNavigation;
			_pageAction = pageAction;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public char Icon
		{
			get
			{
				return _icon;
			}
		}

		public string BackgroundImage
		{
			get
			{
				return _backgroundImage;
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return _backgroundColor;
			}
		}

		public async Task NavigateToMenu(INavigation navigation)
		{
			MenuCoordinator.RaiseMenuSelected(this);

			if (_justNotifyNavigateIntent)
			{
				return;
			}

			if (_customNavigation != null)
			{
				_customNavigation(navigation);
				return;
			}

			int popCount = 0;
			int firstPageToPopIndex = 0;

			for (int i = navigation.NavigationStack.Count - 1; i >= 0; i--)
			{
				if (navigation.NavigationStack[i].GetType() == _pageType)
				{
					firstPageToPopIndex = i + 1;
					popCount = navigation.NavigationStack.Count - 1 - i;
					break;
				}
			}

			if (popCount > 0)
			{
				for (int i = 1; i < popCount; i++)
				{
					navigation.RemovePage(navigation.NavigationStack[firstPageToPopIndex]);
				}

				await navigation.PopAsync();

				return;
			}

			var page = CreateContentPage();

			if (_modal)
			{
				await navigation.PushModalAsync(new NavigationPage(page));
			}
			else
			{
				await navigation.PushAsync(page);
			}
		}

		private Page CreateContentPage()
		{
			var page = Activator.CreateInstance(_pageType) as Page;

			System.Diagnostics.Debug.Assert(page != null);

			return page;
		}

		public bool IsMenu
		{
			get
			{
				return _isMenu;
			}
		}

		public PageActions PageAction
		{
			get
			{
				return _pageAction;
			}
		}

		public Type PageType
		{
			get
			{
				return _pageType;
			}
		}
	}
}