using System;
using System.Collections.ObjectModel;
using TMTK.Models;

namespace TMTK
{
	public class SpeakersVM : ViewModelBase
	{
		public SpeakersVM()
		{
			IsBusy = true;
			LoadSpeakerData();
		}

		private async void LoadSpeakerData()
		{
			try
			{
				
				SpeakersCollection = await SpeakersDefinition.LoadSpeakers();
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

		private ObservableCollection<Speakers> _speakers;
		public ObservableCollection<Speakers> SpeakersCollection
		{
			get { return _speakers; }
			set
			{
				_speakers = value;
				OnPropertyChanged("SpeakersCollection");
			}
		}
	}
}
