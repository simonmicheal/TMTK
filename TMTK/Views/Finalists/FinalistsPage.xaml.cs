using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMTK.Models;
using Xamarin.Forms;

namespace TMTK
{
	public partial class FinalistsPage : ContentPage
	{
		public FinalistsPage()
		{
			InitializeComponent();
			this.BindingContext = new ContestVM();
		}

		public async Task VoteButtonClicked(object sender, EventArgs e) 
		{
			Finalist f = (Finalist)((Button)sender).BindingContext;

			if (f != null)
			{
				var res = await ((ContestVM)this.BindingContext).VoteForFinalist(f);

				//f.HasVoted = res.HasVoted;
			}
		}
	}
}