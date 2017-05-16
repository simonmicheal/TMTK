using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TMTK
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			this.BindingContext = new LoginVM(new NavigationService(Navigation));
		}
	}
}
