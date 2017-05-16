using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TMTK.Models;
using TMTK.Services;
using Xamarin.Forms;

namespace TMTK
{
	public class ContestVM : ViewModelBase
	{
		public ContestVM()
		{
			IsBusy = true;
			Task.Run(() => LoadContestData());
		}

		private async Task LoadContestData()
		{
			try
			{
				var col = await ContestsDefinition.LoadContest();

				if (col != null && col.Count > 0)
				{
					foreach (Finalist f in col)
					{
						f.Vote = await ContestsDefinition.GetContestVoteForContact(f.ContestId.ToString());

						if (f.Vote != null)
						{
							if (f.Vote.FinalistId != f.Id)
							{
								f.Vote.FinalistId = "";
							}
						}
					}
				}

				ContestCollection = col;

				IsBusy = false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<Finalist> VoteForFinalist(Finalist f)
		{
			IsBusy = true;
			f.Vote.FinalistId = f.Id;
			var x = await ContestsDefinition.SaveContestVote(f.Vote);
			await LoadContestData();
			return f;
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

		private Finalist _selectedFinalist;
		public Finalist SelectedFinalist
		{
			get { return _selectedFinalist; }
			set
			{
				_selectedFinalist = value;
        OnPropertyChanged("SelectedFinalist");
			}
		}

		private ObservableCollection<Finalist> _contest;
		public ObservableCollection<Finalist> ContestCollection
		{
			get { return _contest; }
			set
			{
				_contest = value;
				OnPropertyChanged("ContestCollection");
			}
		}

		private ContestVote _contestVote;
		public ContestVote ContestVote
		{
			get { return _contestVote; }
			set
			{
				_contestVote = value;
				OnPropertyChanged("ContestVote");
			}
		}
	}
}
