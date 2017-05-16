using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TMTK
{
	public partial class SpeakersPage : ContentPage
	{
		public SpeakersPage()
		{
			InitializeComponent();
			this.BindingContext = new SpeakersVM();
		}
	}
}
