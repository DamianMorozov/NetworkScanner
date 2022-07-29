// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.ObjectModel;
using SQLite;

namespace NetworkLib.Db;

/// <summary>
/// Sqlite DB helper.
/// </summary>
public class DbHelper
{
    #region Design pattern "Lazy Singleton"

#pragma warning disable CS8618
    private static DbHelper _instance;
#pragma warning restore CS8618
    public static DbHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

    #endregion

    #region Public and private fields, properties, constructor

    private SQLiteAsyncConnection? SqlCon { get; }

    /// <summary>
    /// Current IP range.
    /// </summary>
    public IpRangeEntity IpRangeCurrent { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public DbHelper()
    {
        //string dir = FileSystem.AppDataDirectory;
        string? dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        if (!string.IsNullOrEmpty(dir))
        {
            string databasePath = Path.Combine(dir, "database.db");
            string dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;
            if (string.IsNullOrEmpty(dbEncryptionKey))
            {
                dbEncryptionKey = new Guid().ToString();
                SecureStorage.SetAsync("dbKey", dbEncryptionKey);
            }
            SQLiteConnectionString dbOptions = new(databasePath, true, key: dbEncryptionKey);
            SqlCon = new(dbOptions);
            SqlCon.CreateTableAsync<IpRangeEntity>();
        }
        IpRangeCurrent = new();
    }

    #endregion

    #region Public and private methods

    /// <summary>
    /// Fill IP ranges.
    /// </summary>
    /// <param name="ipRanges"></param>
    /// <param name="items"></param>
    public async Task FillIpRanges(ObservableCollection<IpRangeEntity> ipRanges, ObservableCollection<string> items)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        if (SqlCon == null)
            return;
        List<IpRangeEntity>? ranges = await GetIpRanges();
        if (ranges != null)
            foreach (IpRangeEntity ipRange in ranges)
            {
                ipRanges.Add(ipRange);
                items.Add(ipRange.Name);
            }
    }

    /// <summary>
    /// Get IP ranges.
    /// </summary>
    /// <returns></returns>
    public async Task<List<IpRangeEntity>?> GetIpRanges()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        if (SqlCon == null)
            return null;
        return await SqlCon.Table<IpRangeEntity>().ToListAsync().ConfigureAwait(true);
    }

    /// <summary>
    /// Get IP range.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IpRangeEntity?> GetIpRange(int id)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        if (SqlCon == null)
            return null;
        AsyncTableQuery<IpRangeEntity> query = SqlCon.Table<IpRangeEntity>().Where(t => t.Id == id);
        return await query.FirstOrDefaultAsync().ConfigureAwait(true);
    }

    /// <summary>
    /// Add IP range.
    /// </summary>
    /// <param name="ipRange"></param>
    /// <returns></returns>
    public async Task<int> AddIpRange(IpRangeEntity ipRange)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        if (SqlCon == null)
            return 0;
        return await SqlCon.InsertAsync(ipRange).ConfigureAwait(true);
    }

    /// <summary>
    /// Delete IP range.
    /// </summary>
    /// <param name="ipRange"></param>
    /// <returns></returns>
    public async Task<int> DeleteIpRange(IpRangeEntity ipRange)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        if (SqlCon == null)
            return 0;
        return await SqlCon.DeleteAsync(ipRange).ConfigureAwait(true);
    }

    /// <summary>
    /// Update record.
    /// </summary>
    /// <param name="ipRange"></param>
    /// <returns></returns>
    public async Task<int> UpdateIpRange(IpRangeEntity ipRange)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        if (SqlCon == null)
            return 0;
        return await SqlCon.UpdateAsync(ipRange).ConfigureAwait(true);
    }

    #endregion
}
