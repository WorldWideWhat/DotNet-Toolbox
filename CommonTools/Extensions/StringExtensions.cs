/// <summary>
/// Extension of existing string functions
/// Created: 2022-02-12
/// </summary>

namespace worldwidewhat.CommonTools.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Test content is a numeric value
    /// </summary>
    /// <param name="str"></param>
    /// <returns>boolean</returns>
    public static bool IsNumeric(this string str)
    {
        if(str.IsEmpty(true)) return false;
        System.Text.RegularExpressions.Regex _isNumber = new(@"^\d+$");
        System.Text.RegularExpressions.Match m = _isNumber.Match(str);
        return m.Success;
    }

    /// <summary>
    /// Test if content is empty
    /// </summary>
    /// <param name="str"></param>
    /// <param name="ignoreWhiteSpace">Ignore leading spaces/whitespaces in test</param>
    /// <returns>boolean</returns>
    public static bool IsEmpty(this string str, bool ignoreWhiteSpace=true)
    {
        return ignoreWhiteSpace ? str.Trim().Length < 1 : str.Length < 1;
    }
}
