using System.Text;

namespace BootstrapFormComponents.Helpers;
public static class BfStringHelpers
{
    static int alphaLength_;
    static string alphaNumerics_ = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
    static Random random_;
    static StringBuilder sb_;
    public static string GenerateRandomString(this string s, int length = 5)
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

    static BfStringHelpers()
    {
        alphaLength_ = alphaNumerics_.Length;
    }
}
