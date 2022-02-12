
using System.Data.SqlClient;
/// <summary>
/// Extenstion of existing SqlDataReader functions
/// Created: 2022-02-12
/// </summary>
public static partial class SqlDataReaderExtensions
{
    /// <summary>
    /// Get binary data from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Binary value</returns>
    public static byte[]? GetNullVarBinary(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? null : (byte[])@this.GetSqlBinary(@this.GetOrdinal(field));
    }

    /// <summary>
    /// Get string value from data database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>String value</returns>
    public static string GetNullString(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? string.Empty : @this.GetString(@this.GetOrdinal(field));
    }

    /// <summary>
    /// Get integer value from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Integer value</returns>
    public static int GetNullInt(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetInt32(@this.GetOrdinal(field));
    }

    /// <summary>
    /// Get long value from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Long value</returns>
    public static long GetNullLong(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetInt64(@this.GetOrdinal(field));
    }
    /// <summary>
    /// Get Smallint/short
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Short value</returns>
    public static short GetNullSmallInt(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? (short)0 : @this.GetInt16(@this.GetOrdinal(field));
    }
    /// <summary>
    /// Get boolean from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Boolean value</returns>
    public static bool GetNullBoolean(this SqlDataReader @this, string field)
    {
        return !@this.IsDBNull(@this.GetOrdinal(field)) && Convert.ToBoolean(@this.GetBoolean(@this.GetOrdinal(field)));

    }
    /// <summary>
    /// Det decial value from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Decimal value</returns>
    public static decimal GetNullDec(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetDecimal(@this.GetOrdinal(field));
    }
    /// <summary>
    /// Get DateTime from databas field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>DateTime value</returns>
    public static DateTime GetNullDateTime(this SqlDataReader @this, string field)
    {
        return @this.IsDBNull(@this.GetOrdinal(field)) ? DateTime.MinValue : @this.GetDateTime(@this.GetOrdinal(field));
    }
}
