using System.Linq;

namespace TownOfSalem_Logic
{
    public static class StringUtils
    {
        public static bool IsPasswordValidFormat(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Trim().Length >= 10 &&
                   password.Trim().Length <= 32 && !password.Contains(" ") && password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) && password.Any(char.IsDigit) &&
                   password.ToCharArray().Any(c => "(!#&$%=?@.-;_)".Contains(c.ToString()));
        }
    }
}
