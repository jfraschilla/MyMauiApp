namespace MyMauiApp.Services;

public interface IDataContext
{
    Task<IEnumerable<Account>> GetAllAsync();
    Task<Account> GetAccountAsync(int id);
    Task InsertAccountAsync(Account account);
    Task DeleteAccountAsync(int id);
    Task UpdateAccountAsync(Account account);
    Task<Account> FindByName(string name);
    Task Save();
}
