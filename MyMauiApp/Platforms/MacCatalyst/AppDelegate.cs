using Foundation;

namespace MauiApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MyMauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
