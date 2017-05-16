using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TMTK
{
	public static class MenusDefinition
	{
		private static List<MenuCategory> _samplesCategoryList;
		private static Dictionary<string, MenuCategory> _samplesCategories;
		private static List<Menu> _allMenus;
		private static List<MenuGroup> _samplesGroupedByCategory;

		public static string[] _categoriesColors = {
			"#9A0000",
			"#575757",
			"#861350",
			"#473957",
			"#554666",
			"#5a5586",
			"#4d75a5",
			"#509acb",
			"#5abaeb"
		};

		public static List<MenuCategory> MenusCategoryList
		{
			get
			{
				if (_samplesCategoryList == null)
					InitializeMenus();

				return _samplesCategoryList;
			}
		}

		public static Dictionary<string, MenuCategory> MenusCategories
		{
			get
			{
				if (_samplesCategories == null)
				{
					InitializeMenus();
				}

				return _samplesCategories;
			}
		}

		public static List<Menu> AllMenus
		{
			get
			{
				if (_allMenus == null)
				{
					InitializeMenus();
				}
				return _allMenus;
			}
		}

		public static List<MenuGroup> MenusGroupedByCategory
		{
			get
			{
				if (_samplesGroupedByCategory == null)
				{
					InitializeMenus();
				}

				return _samplesGroupedByCategory;
			}
		}


		internal static void InitializeMenus()
		{
			var categories = new Dictionary<string, MenuCategory>();
			var dashboard = new Dictionary<string, MenuCategory>();

            categories.Add(
				"MENU",
				new MenuCategory
				{
					Name = "Menu",
					BackgroundColor = Color.FromHex(_categoriesColors[0]),
					//	BackgroundImage = MenuData.DashboardImagesList[6],
					Icon = '\uf0e6',
					MenuList = new List<Menu>
				{
					//new Menu(PageActions.LogOut,Color.FromHex(_categoriesColors[0]) ,"Log out", typeof(WelcomePage), MenuData.DashboardImagesList[6], '\uf007'),
					 new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[1]),"Schedule", typeof(SchedulePage), "menu_schedule.png", '\uf073'),
                    new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[0]),"Better Your Best Finalists", typeof(FinalistsPage), "better_your_best_finalists.png", '\uf091'),
                    new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[1]),"The Speakers", typeof(SpeakersPage), "menu_speakers.png", '\uf028'),
					new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[0]),"The Sponsors", typeof(SponsersPage), "menu_sponsors.png", '\uf02c'),
						//new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[5]),"Catalog", typeof(CatalogPage), MenuData.DashboardImagesList[6], '\uf187'),
					//new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[6]),"Producers Club Application", typeof(ProducersPage), MenuData.DashboardImagesList[6], '\uf022'),
                    new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[1]),"St. Jude", typeof(StJudesPage), "donation.png", '\uf02c'),
                    new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[0]),"Nashville Dining & Entertainment", typeof(NashvilleInfoPage), "restaurants_food_pdf.png", '\uf02c'),
                    new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[1]),"Event Floorplan", typeof(EventFloorplanPage), "info_pdf.png", '\uf02c'),
                    new Menu(PageActions.NavigateToPage,false,Color.FromHex(_categoriesColors[0]),"Sponsor Floorplan", typeof(SponsorFloorplanPage), "info_pdf.png", '\uf02c'),

                }
                }
			);

			categories.Add(
			"SETTINGS",
			new MenuCategory
			{
				Name = "Settings",
				BackgroundColor = Color.FromHex(_categoriesColors[2]),
				//BackgroundImage = SampleData.DashboardImagesList[3],
				Icon = '\uf009',
				MenuList = new List<Menu> {
						//new Menu(PageActions.LogOut, true,Color.FromHex(_categoriesColors[0]) ,"Account", typeof(WelcomePage), MenuData.DashboardImagesList[6], '\uf007'),
						//new Menu(PageActions.LogOut,true,Color.FromHex(_categoriesColors[0]) ,"Chat", typeof(WelcomePage), MenuData.DashboardImagesList[6], '\uf007'),
						//new Menu(PageActions.LogOut,true, Color.FromHex(_categoriesColors[0]) ,"Notifications", typeof(WelcomePage), MenuData.DashboardImagesList[6], '\uf007'),
						new Menu(PageActions.LogOut,true,Color.FromHex(_categoriesColors[0]) ,"Log out", typeof(WelcomePage), MenuData.DashboardImagesList[6], '\uf007'),
				}
			}
		);

			_samplesCategories = categories;
			_samplesCategoryList = new List<MenuCategory>();

			foreach (var sample in _samplesCategories.Values)
			{
				_samplesCategoryList.Add(sample);
			}

			_allMenus = new List<Menu>();

			_samplesGroupedByCategory = new List<MenuGroup>();

			foreach (var sampleCategory in MenusCategories.Values)
			{
				var sampleItem = new MenuGroup(sampleCategory.Name.ToUpper());

				foreach (var sample in sampleCategory.MenuList)
				{
					_allMenus.Add(sample);
					sampleItem.Add(sample);
				}

				_samplesGroupedByCategory.Add(sampleItem);
			}
		}

		private static void RootPageCustomNavigation(INavigation navigation)
		{
			MenuCoordinator.RaisePresentMainMenuOnAppearance();
			navigation.PopToRootAsync();
		}
	}

	public class MenuGroup : List<Menu>
	{
		private readonly string _name;

		public MenuGroup(string name)
		{
			_name = name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}
	}
}
