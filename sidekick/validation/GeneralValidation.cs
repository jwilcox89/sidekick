using System.Text.RegularExpressions;

namespace sidekick
{
    public class GeneralValidation
    {
        public static string GetDigits(string input) {

            if (string.IsNullOrEmpty(input))
                return null;

            return Regex.Replace(input, "[^\\d]+", string.Empty);
        }

        public static string GetReadablePhoneNumber(string input) {

            if (string.IsNullOrEmpty(input))
                return null;

            return Regex.Replace(input, "(\\d{3})(\\d{3})(\\d{4})", "$1-$2-$3");
        }
    }
}
