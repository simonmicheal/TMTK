using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache;
using TMTK.Models;
using TMTK.Services;
using Xamarin.Forms;
using System.Reactive.Linq;

namespace TMTK
{
	public class LoginVM : ViewModelBase
	{
		public NavigationService Navigation{get;set;}

		public ICommand LoginCommand { get; private set; }
		bool canLogin = true;

        private string _loginMessage = "Please use your Dashboard Username and Password to Login";
        public string LoginMessage
        {
            get { return _loginMessage; }
            set
            {
                if (value != _loginMessage)
                {
                    _loginMessage = value;
                }

                OnPropertyChanged("LoginMessage");
            }
        }

        private string _errorMessage;
		public string ErrorMessage
		{
			get { return _errorMessage; }
			set
			{
				if (value != _errorMessage)
				{
					_errorMessage = value;
				}

        OnPropertyChanged("ErrorMessage");
			}
		}

		private string _username;
		public string UserName
		{
			get { return _username; }
			set
			{
				if (value != _username)
				{
					_username = value;
				}
				OnPropertyChanged("UserName");
			}
		}

		private string _password;
		public string Password
		{
			get { return _password; }
			set
			{
				if (value != _password)
				{
					_password = value;
				}

				OnPropertyChanged("Password");
			}
		}

		public LoginVM(NavigationService navigation)
		{
			this.Navigation = navigation;
			LoginCommand = new Command(async () => await AuthenticateUser(), () => canLogin);
		}

		public async Task AuthenticateUser()
		{
			try
			{
				ErrorMessage = "";
                LoginMessage = "Logging In. Please Wait...";

				CanInitiateLogin(false);
				AuthenticationService srv = new AuthenticationService();
				LoginModel l = new LoginModel() { UserName = UserName, Password = Password };

				var res = await srv.login(l);

				if (res.Contact == null && res.Status == "Error")
				{
					//Something went wrong display error message
					ErrorMessage = res.ErrorMessage;
				}
				else
				{
					//save the contact to disk
					var r = await BlobCache.UserAccount.InsertObject<Contact>("User",res.Contact,DateTimeOffset.Now.AddDays(30));

                    await this.Navigation.PopModalAsync();
				}

                LoginMessage = "Please use your Dashboard Username and Password to Login";
				CanInitiateLogin(true);

			}
			catch (Exception ex) { throw ex; }
		}

		void CanInitiateLogin(bool value)
		{
			canLogin = value;

			((Command)LoginCommand).ChangeCanExecute();
		}
	}
}