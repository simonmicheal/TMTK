using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace TMTK
{
	public class SchedulesVM : ViewModelBase
	{
		private Menu _selectedMenu;

		public SchedulesVM()
		{
			IsBusy = true;
			LoadScheduleData();
		}

		private async void LoadScheduleData()
		{
			try
			{

				SchedulesGroupedByCategory = await SchedulesDefinition.LoadSchedules();
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

		private ObservableCollection<ScheduleGroup> _schedulesGroupedByCategory;
		public ObservableCollection<ScheduleGroup> SchedulesGroupedByCategory
		{
			get { return _schedulesGroupedByCategory; }
			set
			{
				_schedulesGroupedByCategory = value;
				OnPropertyChanged("SchedulesGroupedByCategory");
			}
		}

		public Menu SelectedMenu
		{
			get
			{
				return _selectedMenu;
			}

			set
			{
				if (value != _selectedMenu)
				{
					_selectedMenu = value;
					OnPropertyChanged("SelectedMenu");
				}
			}
		}
	}
}
