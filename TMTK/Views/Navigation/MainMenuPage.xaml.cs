using System;
using Akavache;
using Xamarin.Forms;

namespace TMTK
{
	public partial class MainMenuPage : ContentPage
	{
		private readonly INavigation _navigation;

		public MainMenuPage(INavigation navigation)
		{
			InitializeComponent();

			_navigation = navigation;

			BindingContext = new MainMenuViewModel(navigation);
		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var sample = menuListView.SelectedItem as Menu;

			if (sample != null)
			{
				switch (sample.PageAction)
				{
					case PageActions.LogOut:
						//Clear cache
						BlobCache.UserAccount.Invalidate("User");
						await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));

						break;

					case PageActions.StJudes:
						Device.OpenUri(new Uri(@"http://www.robinsbigseminar.com/stjude"));
						break;

					case PageActions.NavigateToPage:

						if (sample.PageType == typeof(RootPage))
						{
							await DisplayAlert("Hey", string.Format("You are already here, on sample {0}.", sample.Name), "OK");
						}
						else
						{
							await sample.NavigateToMenu(_navigation);
						}
						break;
				}

				menuListView.SelectedItem = null;
			}
		}

		private async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}
	}
}
