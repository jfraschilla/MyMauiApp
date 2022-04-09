using CommunityToolkit.Mvvm.Input;

namespace MyMauiApp.ViewModels;

public class CreatePageViewModel : ObservableObject
{
    private IDataContext _dataContext;
    private Account _account;

    public Account NewAccount { get => _account; set => SetProperty(ref _account, value); }
    public AsyncRelayCommand SaveCommand { get; private set; }
    public CreatePageViewModel(IDataContext dataContext)
    {
        _dataContext = dataContext;
        NewAccount = new Account();
        SaveCommand = new AsyncRelayCommand(AddAccount);
    }

    private async Task AddAccount()
    {
        var accountFound = await _dataContext.FindByName(NewAccount.AccountName);
        if (accountFound is not null)
        {
            await Application.Current.MainPage.DisplayAlert("Alert", "Account alreaady exists", "OK");
            return;
        }

        await _dataContext.InsertAccountAsync(NewAccount);
        NewAccount.AccountName = String.Empty;
        NewAccount.UserName = String.Empty;
        NewAccount.Password = String.Empty;
        await Shell.Current.GoToAsync("..");
    }
}
