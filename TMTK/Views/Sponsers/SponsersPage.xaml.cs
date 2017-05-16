using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TMTK
{
	public partial class SponsersPage : ContentPage
	{
		public SponsersPage()
		{
			InitializeComponent();
			this.BindingContext = new SponsorsVM();
		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null; // de-select the r
		}
	}
}
