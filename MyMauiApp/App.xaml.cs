#if __ANDROID__
using Android.Content.Res;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace MyMauiApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
		{
#if __ANDROID__
			handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif
		});

		MainPage = new MobileShell();

	}

    protected override void OnStart()
    {
        base.OnStart();
    }
}
