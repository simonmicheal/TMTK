using System;
using System.Collections.Generic;
using TMTK.Models;
using Xamarin.Forms;

namespace TMTK
{
	public partial class ScheduleDetails : ContentPage
	{
		public ScheduleDetails(Session s)
		{
			InitializeComponent();
			this.BindingContext = new ScheduleDetailsVM(s);

		}

		public async void OnSpeakerTapped(object sender, EventArgs e)
		{
				var details = new SpeakerDetails(((ScheduleDetailsVM)BindingContext).CurrentSpeaker);
				await Navigation.PushAsync(details);
		}

		public async void OnSponsorTapped(object sender, EventArgs e)
		{
			if (sender != null)
			{
				var details = new SponsersPage();
				await Navigation.PushAsync(details);

			}
		}
	}
}
