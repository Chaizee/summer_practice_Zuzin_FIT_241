using System.Linq;
namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string startString)
    {
        if (startString == null || startString == "")
        {
            return false;
        }

        var normalString = new string(startString.ToLower().Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());

        if (normalString == "")
        {
            return false;
        }
        
        var reversedString = new string(normalString.Reverse().ToArray());

        return normalString == reversedString;
    }
}
