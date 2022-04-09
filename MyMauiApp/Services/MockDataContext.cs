namespace MyMauiApp.Services;

public class MockDataContext : IDataContext
{
    private List<Account> _accounts;
    private Stack<int> _idStack;

    public MockDataContext()
    {
        _idStack = new Stack<int>(Enumerable.Range(1,100).Reverse());
        _accounts = new List<Account>()
        { 
            new Account {Id=_idStack.Pop(), AccountName="Account1", UserName="johndoe@gmail.com", Password="123456"},
            new Account {Id=_idStack.Pop(), AccountName="Account2", UserName="johndoe@gmail.com", Password="234567"},
            new Account {Id=_idStack.Pop(), AccountName="Account3", UserName="johndoe@gmail.com", Password="345678"}            
        };
        //for (int i = 4; i < 20; i++)
        //{
        //    var id = _idStack.Pop();
        //    _accounts.Add(new Account { Id = id, AccountName = $"Account{id}", UserName = $"User{id}", Password = $"Password{id}"});
        //}

    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        await Task.Delay(1000);
        var accounts = _accounts.AsEnumerable<Account>();
        return accounts;
    }

    public async Task<Account> GetAccountAsync(int id)
    {
        await Task.Delay(1000);
        var account = _accounts.Find(x => x.Id == id);
        return account;
    }

    public async Task InsertAccountAsync(Account account)
    {
        await Task.Delay(1000);
        var id = _idStack.Pop();
        account.Id = id;
        _accounts.Add(new Account { AccountName = account.AccountName, UserName = account.UserName, Password = account.Password });
    }

    public async Task DeleteAccountAsync(int id)
    {
        await Task.Delay(1000);
        _accounts.Remove(_accounts.Where(x => x.Id == id).FirstOrDefault());
        _idStack.Push(id);
    }

    public async Task UpdateAccountAsync(Account account)
    {
        await Task.Delay(1000);
    }

    public async Task<Account> FindByName(string name)
    {
        await Task.Delay(1000);
        //var account = _accounts.Where(x => x.AccountName.ToLower() == name.ToLower).FirstOrDefault();
        var account = _accounts.Where(x => string.Equals(x.AccountName, name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        return account;
    }

    public async Task Save()
    {
        await Task.Delay(1000);
    }


}
