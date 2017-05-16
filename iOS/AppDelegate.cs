using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using WindowsAzure.Messaging;

namespace TMTK.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{

		private SBNotificationHub Hub { get; set; }


		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

			var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
				UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
				new NSSet());

			UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
			UIApplication.SharedApplication.RegisterForRemoteNotifications();

			global::Xamarin.Forms.Forms.Init();

			Appearance.Configure();

			LoadApplication(new App());

			// Process any potential notification data from launch
			ProcessNotification(options);


			return base.FinishedLaunching(app, options);
		}

		public override void RegisteredForRemoteNotifications(UIApplication app, NSData deviceToken)
		{
			// TODO add your own access key
			var hub = new SBNotificationHub("Endpoint=sb://ppnotifications.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=7VbttLtftP1IDZS+yH3afWuL+jVlGOv2ghzvSeC8xms=",
	"tmtknotificationhub");


			NSSet tags = null; // create tags if you want
			hub.RegisterNativeAsync(deviceToken, tags, (errorCallback) =>
									{
										if (errorCallback != null)
										{
											var alert = new UIAlertView("ERROR!", errorCallback.ToString(), null, "OK", null);
											alert.Show();
										}
									});

		}

		public override void ReceivedRemoteNotification(UIApplication app, NSDictionary userInfo)
		{
			// Process a notification received while the app was already open
			ProcessNotification(userInfo);
		}

		void ProcessNotification(NSDictionary userInfo)
		{
			if (userInfo == null)
				return;

			Console.WriteLine("Received Notification");

			var apsKey = new NSString("aps");

			if (userInfo.ContainsKey(apsKey))
			{

				var alertKey = new NSString("alert");

				var aps = (NSDictionary)userInfo.ObjectForKey(apsKey);

				if (aps.ContainsKey(alertKey))
				{
					var alert = (NSString)aps.ObjectForKey(alertKey);

					try
					{

						var avAlert = new UIAlertView("TMTK Update", alert, null, "OK", null);
						avAlert.Show();

					}
					catch (Exception ex)
					{

					}

					Console.WriteLine("Notification: " + alert);
				}
			}

		}
	}
}