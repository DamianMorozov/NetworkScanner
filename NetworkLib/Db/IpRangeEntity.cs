using SQLite;

namespace NetworkLib.Db;

/// <summary>
/// IP range.
/// </summary>
public class IpRangeEntity
{
    #region Public and private fields, properties, constructor

    /// <summary>
    /// ID field.
    /// </summary>
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    /// <summary>
    /// Name field.
    /// </summary>
    public string Name { get; set; }
    public string IpStart { get; set; }
    public string IpEnd { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public IpRangeEntity()
    {
        IpStart = string.Empty;
        IpEnd = string.Empty;
    }

    #endregion
}
