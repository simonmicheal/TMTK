using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMTK.Models;
using System.Linq;
namespace TMTK
{
	public class SponsorsVM : ViewModelBase
	{

		public SponsorsVM()
		{
			IsBusy = true;
			LoadSponsorData();
		}

		private async void LoadSponsorData()
		{
			try
			{
				SponsorsGroupedCollection = await SponsorDefinition.LoadSponsors();
				IsBusy = false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				_isBusy = value;
				OnPropertyChanged("IsBusy");
			}
		}

		private ObservableCollection<SponsorGroupingClass<string, Sponsor>> _sponsors;
		public ObservableCollection<SponsorGroupingClass<string, Sponsor>> SponsorsGroupedCollection
		{
			get { return _sponsors; }
			set
			{
				_sponsors = value;
				OnPropertyChanged("SponsorsGroupedCollection");
			}
		}
	}
}
