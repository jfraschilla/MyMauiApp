namespace MyMauiApp.Views;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _vm => BindingContext as MainPageViewModel;

    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.InitializeAsync();
    }
}