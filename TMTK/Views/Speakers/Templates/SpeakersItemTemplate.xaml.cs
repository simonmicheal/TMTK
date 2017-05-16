using System;
using System.Collections.Generic;
using TMTK.Models;
using Xamarin.Forms;

namespace TMTK
{
	public partial class SpeakersItemTemplate : ContentView
	{
		public SpeakersItemTemplate()
		{
			InitializeComponent();
		}

		private async void OnImageTapped(Object sender, EventArgs e)
		{
			var speak = ((ContentView)sender).BindingContext;

			if (speak != null)
			{
				var details = new SpeakerDetails((Speakers)speak);
				await Navigation.PushAsync(details);
			}
		}
	}
}
