using System;
using TMTK.Models;
using Xamarin.Forms;
using System.Linq;

namespace TMTK
{
	public class ScheduleDetailsVM : ViewModelBase
	{
		public ScheduleDetailsVM(Session s)
		{
			SelectedSession = s;
			IsBusy = true;
			LoadSpeakerData();
		}

		private async void LoadSpeakerData()
		{
			try
			{
				if (SelectedSession.SpeakerId != null)
				{
					this.CurrentSpeaker = await SpeakersDefinition.LoadSpeaker(SelectedSession.SpeakerId.ToString());
					this.IsSpeakerPicture = true;
				}
				else
				{
					this.IsSpeakerPicture = false;
				}

				if (SelectedSession.SponsorId != null)
				{
					this.CurrentSponsor = await SponsorDefinition.LoadSponsor(SelectedSession.SponsorId.ToString());
					this.IsSponsorPicture = true;
				}
				else
				{
					IsSponsorPicture = false;
				}

				IsBusy = false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private bool _isSpeakerPicture;
		public bool IsSpeakerPicture
		{
			get
			{
				return _isSpeakerPicture;
			}
			set
			{
				_isSpeakerPicture = value;
				OnPropertyChanged("IsSpeakerPicture");
			}
		}

		private bool _isSponsorPicture;
		public bool IsSponsorPicture
		{
			get
			{
				return _isSponsorPicture;
			}
			set
			{
				_isSponsorPicture = value;
				OnPropertyChanged("IsSponsorPicture");
			}
		}

		private Speakers _currentSpeaker;
		public Speakers CurrentSpeaker
		{
			get
			{
				return _currentSpeaker;
			}
			set
			{
				_currentSpeaker = value;
				OnPropertyChanged("CurrentSpeaker");
			}
		}

		private Sponsor _currentSponsor;
		public Sponsor CurrentSponsor
		{
			get
			{
				return _currentSponsor;
			}
			set
			{
				_currentSponsor = value;
				OnPropertyChanged("CurrentSponsor");
			}
		}

		private Session _selectedSession;
		public Session SelectedSession
		{
			get { return _selectedSession; }
			set
			{
				_selectedSession = value;
				OnPropertyChanged("SelectedSession");
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
	}
}

