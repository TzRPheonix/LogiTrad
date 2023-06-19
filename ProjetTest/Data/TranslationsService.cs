using SQLite;
namespace ProjetTest.Data;
public class TranslationsService
{
    string _dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection conn;
    public TranslationsService(string dbPath)
    {
        _dbPath = dbPath;
    }
    private async Task InitAsync()
    {
        // Don't Create database if it exists
        if (conn != null)
            return;
        // Create database and Translations Table
        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Translation>();
    }
    public async Task<List<Translation>> GetTranslationsAsync()
    {
        await InitAsync();
        return await conn.Table<Translation>().ToListAsync();
    }
    public async Task<Translation> CreateTranslationAsync(
        Translation paramTranslation)
    {
        // Insert
        System.Diagnostics.Debug.WriteLine(paramTranslation);
        await conn.InsertAsync(paramTranslation);
        // return the object with the auto incremented Id populated
        return paramTranslation;
    }
    public async Task<Translation> UpdateTranslationAsync(
        Translation paramTranslation)
    {
        // Update
        await conn.UpdateAsync(paramTranslation);
        // Return the updated object
        return paramTranslation;
    }
    public async Task<Translation> DeleteTranslationAsync(
        Translation paramTranslation)
    {
        // Delete
        await conn.DeleteAsync(paramTranslation);
        return paramTranslation;
    }
}