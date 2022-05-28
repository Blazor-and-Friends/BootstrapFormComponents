using System.Text;

namespace BootstrapFormComponents.Helpers;
public static class BfStringHelpers
{
    static Random random_;
    static StringBuilder sb_;
    public static string GenerateRandomString(this string s, int length = 5)
    {
        string alphaNumerics = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
        int alphaLength = alphaNumerics.Length;

        if (random_ == null) random_ = new Random();
        if (sb_ == null) sb_ = new StringBuilder();
        else sb_.Clear();

        for (int i = 0; i < length; i++)
        {
            int idx = random_.Next(0, alphaLength);
            sb_.Append(alphaNumerics[idx]);
        }

        return sb_.ToString();
    }
}
