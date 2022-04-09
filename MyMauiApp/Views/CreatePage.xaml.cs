namespace MyMauiApp.Views;

public partial class CreatePage : ContentPage
{
	public CreatePage(CreatePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}