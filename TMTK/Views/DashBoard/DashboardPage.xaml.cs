using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TMTK
{
	public partial class DashboardPage : ContentPage
	{
		private readonly INavigation _navigation;
public uint animationDuration = 250;

		public DashboardPage(INavigation navigation)
		{
			InitializeComponent();

			_navigation = navigation;
			this.BindingContext = new DashboardVM();
		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var sample = dashboardListView.SelectedItem as Menu;

			try
			{
				await AnimateItem(this, animationDuration);

				if (sample != null)
				{
					switch (sample.PageAction)
					{
						case PageActions.NavigateToPage:
							var p = CreateContentPage(sample.PageType);
							await Navigation.PushAsync(p);
							break;
					}
				}
			}
			finally
			{
				//_processingTag = false;

			}
			dashboardListView.SelectedItem = null;
		}

		private async Task AnimateItem(Page uiElement, uint duration)
		{
			var originalOpacity = uiElement.Opacity;

			await uiElement.FadeTo(.5, duration / 2, Easing.CubicIn);
			await uiElement.FadeTo(originalOpacity, duration / 2, Easing.CubicIn);
		}

		private Page CreateContentPage(Type _pageType)
		{
			var page = Activator.CreateInstance(_pageType) as Page;

			System.Diagnostics.Debug.Assert(page != null);

			return page;
		}



	}
}
