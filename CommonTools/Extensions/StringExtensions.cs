/// <summary>
/// Extension of existing string functions
/// Created: 2022-02-12
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Test content is a numeric value
    /// </summary>
    /// <param name="this"></param>
    /// <returns>boolean</returns>
    public static bool IsNumeric(this string @this)
    {
        System.Text.RegularExpressions.Regex _isNumber = new(@"^\d+$");
        System.Text.RegularExpressions.Match m = _isNumber.Match(@this);
        return m.Success;
    }

}
