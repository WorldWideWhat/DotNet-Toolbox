namespace System
{
    /// <summary>
    /// DateTime extension functions
    /// Created: 2022-02-12
    /// Author: coder@worldwidewhat.dk
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Timestamp string (yyyyMMddHHmmss)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>TimestampString</returns>
        public static string ToTimestampString(this DateTime value) => value.ToString("yyyyMMddHHmmss");
        /// <summary>
        /// Timestamp string long format (yyyyMMddHHmmssttt)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLongTimestampString(this DateTime value) => value.ToString("yyyyMMddHHmmssttt");

        /// <summary>
        /// Date string (yyyyMMdd)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime value) => value.ToString("yyyyMMdd");

        /// <summary>
        /// Unix timestamp value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime value) => Convert.ToInt64(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

    }
}
