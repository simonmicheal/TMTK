using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TMTK
{
	public class NavigationService : INavigation
	{
		private readonly INavigation _navigation;
		private readonly Action<Page, bool> _pushAsyncReplacement;

		public NavigationService(INavigation navigation)
		{
			Debug.Assert(navigation != null);

			_navigation = navigation;
		}

		public NavigationService(INavigation navigation, Action<Page, bool> pushAsyncReplacement) : this(navigation)
		{
			_pushAsyncReplacement = pushAsyncReplacement;
		}

		public Task PushAsync(Page page)
		{
			if (_pushAsyncReplacement != null)
			{
				return BeginInvokeOnMainThreadAsync(() => _pushAsyncReplacement(page, true));
			}

			return _navigation.PushAsync(page);
		}

		public Task PushAsync(Page page, bool animated)
		{
			if (_pushAsyncReplacement != null)
			{
				return BeginInvokeOnMainThreadAsync(() => _pushAsyncReplacement(page, animated));
			}

			return _navigation.PushAsync(page, animated);
		}

		public Task<Page> PopAsync()
		{
			if (_pushAsyncReplacement != null)
			{
				throw new NotImplementedException();
			}

			return _navigation.PopAsync();
		}

		public Task<Page> PopAsync(bool animated)
		{
			if (_pushAsyncReplacement != null)
			{
				throw new NotImplementedException();
			}

			return _navigation.PopAsync(animated);
		}

		public Task PopToRootAsync()
		{
			return _navigation.PopToRootAsync();
		}

		public Task PopToRootAsync(bool animated)
		{
			return _navigation.PopToRootAsync(animated);
		}

		public Task PushModalAsync(Page page)
		{
			return _navigation.PushModalAsync(page);
		}

		public Task PushModalAsync(Page page, bool animated)
		{
			return _navigation.PushModalAsync(page, animated);
		}

		public Task<Page> PopModalAsync()
		{
			return _navigation.PopModalAsync();
		}

		public Task<Page> PopModalAsync(bool animated)
		{
			return _navigation.PopModalAsync(animated);
		}

		public void RemovePage(Page page)
		{
			_navigation.RemovePage(page);
		}

		public void InsertPageBefore(Page page, Page before)
		{
			_navigation.InsertPageBefore(page, before);
		}

		public System.Collections.Generic.IReadOnlyList<Page> NavigationStack
		{
			get
			{
				return _navigation.NavigationStack;
			}
		}

		public System.Collections.Generic.IReadOnlyList<Page> ModalStack
		{
			get
			{
				return _navigation.ModalStack;
			}
		}

		public static Task BeginInvokeOnMainThreadAsync(Action action)
		{
			TaskCompletionSource<object> completitionSource = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(() =>
				{
					try
					{
						action();
						completitionSource.SetResult(null);
					}
					catch (Exception ex)
					{
						completitionSource.SetException(ex);
					}
				});
			return completitionSource.Task;
		}
	}
}
