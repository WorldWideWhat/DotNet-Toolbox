using System.Data.SqlClient;

    public static partial class SqlDataReaderExtensions
    {
        public static byte[]? GetNullVarBinary(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? null : (byte[])@this.GetSqlBinary(@this.GetOrdinal(field));
        }

        public static string GetNullString(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? string.Empty : @this.GetString(@this.GetOrdinal(field));
        }

        public static int GetNullInt(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetInt32(@this.GetOrdinal(field));
        }

        public static long GetNullLong(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetInt64(@this.GetOrdinal(field));
        }
        public static int GetNullSmallInt(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetInt16(@this.GetOrdinal(field));
        }
        public static bool GetNullByte(this SqlDataReader @this, string field)
        {
            return !@this.IsDBNull(@this.GetOrdinal(field)) && Convert.ToBoolean(@this.GetByte(@this.GetOrdinal(field)));

        }
        public static decimal GetNullDec(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? 0 : @this.GetDecimal(@this.GetOrdinal(field));
        }

        public static DateTime GetNullDateTime(this SqlDataReader @this, string field)
        {
            return @this.IsDBNull(@this.GetOrdinal(field)) ? DateTime.MinValue : @this.GetDateTime(@this.GetOrdinal(field));
        }
    }
