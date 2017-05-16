using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;
using TMTK.Models;
using Akavache;
using System.Collections.Generic;
using System.Reactive.Linq;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TMTK
{
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;
		public static Contact CurrentContact { get; set; }

		public App()
		{
			InitializeComponent();

			MainPage = GetMainPage();
			MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
		}

		protected override void OnStart()
		{
			base.OnStart();

			BlobCache.ApplicationName = "TMTK";
			BlobCache.EnsureInitialized();
		}

		public static Page GetMainPage()
		{
			return new RootPage();
		}

		public static bool IsAuthenticated()
		{
			//Get the cached contact
			var task = Task.Run(() => GetCurrentContact());

			if (task.Result != null)
			{
				CurrentContact = task.Result;
				return true;
			}

			return false;
		}

		public static async Task<string> GetUsersSession()
		{
			try
			{
				var u = await GetCurrentContact();

				if (u != null)
				{
					return u.SessionToken;
				}
			}
			catch
			{
				//for now we want to have the service go get information
				return null;
			}

			return null;
		}

		public static async Task<Contact> GetCurrentContact()
		{
			try
			{
				return await BlobCache.UserAccount.GetObject<Contact>("User").FirstOrDefaultAsync();
			}
			catch (KeyNotFoundException)
			{
				return null;
			}
		}
	}
}
