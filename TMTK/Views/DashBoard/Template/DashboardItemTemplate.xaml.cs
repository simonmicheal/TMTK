using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TMTK
{
	public partial class DashboardItemTemplate : ContentView
	{
		public uint animationDuration = 250;
		public bool _processingTag = false;

		public static BindableProperty ShowBackgroundImageProperty =
			BindableProperty.Create("ShowBackgroundImage", typeof(bool),
				typeof(DashboardItemTemplate),
				true,
				defaultBindingMode: BindingMode.OneWay
			);

		public bool ShowBackgroundImage
		{
			get { return (bool)GetValue(ShowBackgroundImageProperty); }
			set { SetValue(ShowBackgroundImageProperty, value); }
		}

		public static BindableProperty ShowBackgroundColorProperty =
			BindableProperty.Create("ShowBackgroundColor", typeof(bool),
				typeof(DashboardItemTemplate),
				false,
				defaultBindingMode: BindingMode.OneWay
			);

		public bool ShowBackgroundColor
		{
			get { return (bool)GetValue(ShowBackgroundColorProperty); }
			set { SetValue(ShowBackgroundColorProperty, value); }
		}

		public static BindableProperty ShowiconColoredCircleBackgroundProperty =
			BindableProperty.Create("ShowiconColoredCircleBackground", typeof(bool),
				typeof(DashboardItemTemplate),
				true,
				defaultBindingMode: BindingMode.OneWay
			);

		public bool ShowiconColoredCircleBackground
		{
			get { return (bool)GetValue(ShowiconColoredCircleBackgroundProperty); }
			set { SetValue(ShowiconColoredCircleBackgroundProperty, value); }
		}

		public static BindableProperty TextColorProperty =
			BindableProperty.Create("TextColor", typeof(Color),
				typeof(DashboardItemTemplate),
				defaultValue: Color.White,
				defaultBindingMode: BindingMode.OneWay
			);

		public Color TextColor
		{
			get { return (Color)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value); }
		}

		public DashboardItemTemplate()
		{
			InitializeComponent();
		}

		public async void OnWidgetTapped(object sender, EventArgs e)
		{
			if (_processingTag)
			{
				return;
			}

			_processingTag = true;

			try
			{
				await AnimateItem(this, animationDuration);

			//	await MenuListFromCategoryPage.NavigateToCategory((MenuCategory)BindingContext, Navigation);
			}
			finally
			{
				_processingTag = false;
			}
		}

		private async Task AnimateItem(View uiElement, uint duration)
		{
			var originalOpacity = uiElement.Opacity;

			await uiElement.FadeTo(.5, duration / 2, Easing.CubicIn);
			await uiElement.FadeTo(originalOpacity, duration / 2, Easing.CubicIn);
		}
	}
}
