using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Mindscape.Raygun4Net;
using UIKit;

namespace TMTK.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{

			RaygunClient.Initialize("ty6buJ84nX2YkB137J21TQ==").AttachCrashReporting().AttachPulse();
			UIApplication.Main(args, null, "AppDelegate");


			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}
