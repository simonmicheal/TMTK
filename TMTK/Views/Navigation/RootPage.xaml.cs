using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TMTK
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage()
		{
			InitializeComponent();

			// Empty pages are initially set to get optimal launch experience
			Master = new ContentPage { Title = " " };
			Detail = new NavigationPage(new ContentPage());
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			if (!App.IsAuthenticated())
			{
				await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));

				await Task.Delay(500)
					.ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));
			}
			else
			{
				InitializeMasterDetail();
			}
		}

		private void InitializeMasterDetail()
		{
			Master = new MainMenuPage(new NavigationService(Navigation,LaunchSampleInDetail));
			Detail = new NavigationPage(new DashboardPage(Navigation));
		}

		private void LaunchSampleInDetail(Page page, bool animated)
		{
			// CustomNavBarPage must be handled differently because XF seems not to be considering the
			// "NavigationPage.SetHasNavigationBar(this, false);" when you add the page as the 
			// root of the NavigationPage, when you are working in Android.
			//if (page is CustomNavBarPage)
			//{
			//	var navigationPage = new NavigationPage(new ContentPage());

			//	Detail = navigationPage;

			//	navigationPage.PushAsync(page, false);
			//}
			//else
			//{
				Detail = new NavigationPage(page);
			//}

			IsPresented = false;
		}
	}
}