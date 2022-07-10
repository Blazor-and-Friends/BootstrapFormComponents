using System.Text;
using System.Text.RegularExpressions;

namespace BootstrapFormComponents.Helpers;
public static class BfStringHelpers
{
    static int alphaLength_;
    static string alphaNumerics_ = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
    static Random random_;
    static StringBuilder sb_;
    public static string GenerateRandomString(this string s, int length = 6)
    {
        if (random_ == null) random_ = new Random();
        if (sb_ == null) sb_ = new StringBuilder();
        else sb_.Clear();

        for (int i = 0; i < length; i++)
        {
            int idx = random_.Next(0, alphaLength_);
            sb_.Append(alphaNumerics_[idx]);
        }

        return sb_.ToString();
    }

    public static string StripPhoneDigits(this string s)
    {
        return Regex.Replace(s, "[^0-9]", "");
    }

    public static string FormatPhoneNumber(this string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return s;
        s = s.StripPhoneDigits();

        int length = s.Length;

        string countryCode;
        string areaCode;
        string exchange;
        string line;

        switch (length)
        {
            case int n when (n <= 3):
                return $"({s}) -";
            case int n when (n <= 6):
                areaCode = s.Substring(0, 3);
                exchange = s.Substring(3);
                return $"({areaCode}) {exchange}-";
            case int n when (n <= 10):
                areaCode = s.Substring(0, 3);
                exchange = s.Substring(3, 3);
                line = s.Substring(6);
                return $"({areaCode}) {exchange}-{line}";
            default:
                return s;
        }
    }

    static BfStringHelpers()
    {
        alphaLength_ = alphaNumerics_.Length;
    }
}
