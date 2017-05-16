using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TMTK
{
	public partial class CategoriesListWithIconsItemTemplate : ContentView
	{
		public uint animationDuration = 250;
		public bool _processingTag = false;

		public CategoriesListWithIconsItemTemplate()
		{
			InitializeComponent();
		}

		//public async void OnWidgetTapped(object sender, EventArgs e)
		//{
		//	if (_processingTag)
		//	{
		//		return;
		//	}

		//	_processingTag = true;

		//	try
		//	{
		//		await AnimateItem(this, animationDuration);
		//		var sample = (Menu)BindingContext;

		//		if (sample != null)
		//		{
		//			switch (sample.PageAction)
		//			{
		//				case PageActions.NavigateToPage:
		//					var p = CreateContentPage(sample.PageType);
		//					await Navigation.PushAsync(p);
		//					break;
		//			}
		//		}
		//	}
		//	finally
		//	{
		//		_processingTag = false;
		//	}
		//}

		//private async Task AnimateItem(View uiElement, uint duration)
		//{
		//	var originalOpacity = uiElement.Opacity;

		//	await uiElement.FadeTo(.5, duration / 2, Easing.CubicIn);
		//	await uiElement.FadeTo(originalOpacity, duration / 2, Easing.CubicIn);
		//}

		//private Page CreateContentPage(Type _pageType)
		//{
		//	var page = Activator.CreateInstance(_pageType) as Page;

		//	System.Diagnostics.Debug.Assert(page != null);

		//	return page;
		//}
	}

}
