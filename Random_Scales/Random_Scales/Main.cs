using UIKit;

//TODO: Turn tab pages into a generic class
//TODO: [Bug] Having no items selected causes a crash
//TODO: Expanded scale view
//TODO: Reset all buttons on the settings tab
//TODO: Variable naming convention needs to be consistent

namespace ScalesApp
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}