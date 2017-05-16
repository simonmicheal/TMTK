using System;
using System.Collections.Generic;
using TMTK.Models;
using Xamarin.Forms;

namespace TMTK
{
	public partial class SpeakerDetails : ContentPage
	{
		public SpeakerDetails()
		{
			InitializeComponent();
		}

		public SpeakerDetails(Speakers details)
		{
      InitializeComponent();

			this.BindingContext = details;
		}

		async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopAsync();
		}
	}
}
