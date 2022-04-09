using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyMauiApp.ViewModels;

public class MainPageViewModel : ObservableObject
{
    private IDataContext _context;
    private bool _isBusy;
    private Account _selectedAccount;

    public ObservableCollection<Account> Accounts { get; private set; }
    public AsyncRelayCommand RefreshCommand { get; private set; }
    public AsyncRelayCommand CreateCommand { get; private set; }
    public bool IsBusy { get=>_isBusy; set => SetProperty(ref _isBusy, value); } 
    public Account SelectedAccount { get=>_selectedAccount;  set => SetProperty(ref _selectedAccount, value); }

    public MainPageViewModel(IDataContext context)
    {
        _context = context;
        Accounts = new ObservableCollection<Account>();
        RefreshCommand = new AsyncRelayCommand(Refresh);
        CreateCommand = new AsyncRelayCommand(CreateNewAccount);

        Accounts.Add(new Account { Id = 1, AccountName = "a1", UserName = "a2", Password = "a3" });
    }

    async Task CreateNewAccount()
    {
        var route = $"{nameof(CreatePage)}";
        await Shell.Current.GoToAsync(route);
    }

    internal async Task InitializeAsync()
    {
        await Refresh();
    }

    async Task Refresh()
    {
        IsBusy = true;

        var accounts = await _context.GetAllAsync();

        if (Accounts.Count > 0)
        {
            Accounts.Clear();
        }
        foreach (var item in accounts)
        {
            Accounts.Add(item);
        }
        IsBusy = false;
    }

}
