
using System.Data.SqlClient;

namespace worldwidewhat.CommonTools.Extensions;

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
    public static byte[]? GetNullVarBinary(this SqlDataReader reader, string field)
    {
        return reader.IsDBNull(reader.GetOrdinal(field)) ? null : reader.GetSqlBytes(reader.GetOrdinal(field)).Buffer;
    }

    /// <summary>
    /// Get string value from data database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>String value</returns>
    public static string GetNullString(this SqlDataReader reder, string field)
    {
        return reder.IsDBNull(reder.GetOrdinal(field)) ? string.Empty : reder.GetString(reder.GetOrdinal(field));
    }

    /// <summary>
    /// Get integer value from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Integer value</returns>
    public static int GetNullInt(this SqlDataReader reader, string field)
    {
        return reader.IsDBNull(reader.GetOrdinal(field)) ? 0 : reader.GetInt32(reader.GetOrdinal(field));
    }

    /// <summary>
    /// Get long value from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Long value</returns>
    public static long GetNullLong(this SqlDataReader reader, string field)
    {
        return reader.IsDBNull(reader.GetOrdinal(field)) ? 0 : reader.GetInt64(reader.GetOrdinal(field));
    }
    /// <summary>
    /// Get Smallint/short
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Short value</returns>
    public static short GetNullSmallInt(this SqlDataReader reader, string field)
    {
        return reader.IsDBNull(reader.GetOrdinal(field)) ? (short)0 : reader.GetInt16(reader.GetOrdinal(field));
    }
    /// <summary>
    /// Get boolean from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Boolean value</returns>
    public static bool GetNullBoolean(this SqlDataReader reader, string field)
    {
        return !reader.IsDBNull(reader.GetOrdinal(field)) && Convert.ToBoolean(reader.GetBoolean(reader.GetOrdinal(field)));

    }
    /// <summary>
    /// Det decial value from database field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>Decimal value</returns>
    public static decimal GetNullDec(this SqlDataReader reader, string field)
    {
        return reader.IsDBNull(reader.GetOrdinal(field)) ? 0 : reader.GetDecimal(reader.GetOrdinal(field));
    }
    /// <summary>
    /// Get DateTime from databas field
    /// </summary>
    /// <param name="field">Database field</param>
    /// <returns>DateTime value</returns>
    public static DateTime GetNullDateTime(this SqlDataReader reader, string field)
    {
        return reader.IsDBNull(reader.GetOrdinal(field)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(field));
    }
}
