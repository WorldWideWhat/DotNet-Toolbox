


public static partial class StringExtensions
{
    public static bool IsNumeric(this string @this)
    {
        System.Text.RegularExpressions.Regex _isNumber = new(@"^\d+$");
        System.Text.RegularExpressions.Match m = _isNumber.Match(@this);
        return m.Success;
    }

}
