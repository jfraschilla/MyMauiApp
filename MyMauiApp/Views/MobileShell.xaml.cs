namespace MyMauiApp.Views;

public partial class MobileShell : Shell
{
	public MobileShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));

	}
}