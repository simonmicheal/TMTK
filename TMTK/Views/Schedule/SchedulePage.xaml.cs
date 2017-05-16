using System;
using System.Collections.Generic;
using System.Linq;
using TMTK.Models;
using Xamarin.Forms;

namespace TMTK
{
	public partial class SchedulePage : ContentPage
	{
		public SchedulePage()
		{
			InitializeComponent();
			this.BindingContext = new SchedulesVM();
		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//Session session = (Session)((ListView)sender).SelectedItem; // de-select the row

			//if (session != null && (!string.IsNullOrEmpty(session.SessionDescription) || session.SpeakerId != null || session.SponsorId != null))
			//{

			//	var details = new ScheduleDetails((Session)session);
			//	await Navigation.PushAsync(details);

			//	((ListView)sender).SelectedItem = null;
			//}
			var session = ((ListView)sender).SelectedItem; // de-select the row

			if (session != null)
			{
				if (!String.IsNullOrEmpty(((Session)session).SessionDescription))
				{
					var details = new ScheduleDetails((Session)session);
					await Navigation.PushAsync(details);

					((ListView)sender).SelectedItem = null;
				}
			}
		}
	}
}
