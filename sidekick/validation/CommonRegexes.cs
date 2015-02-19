namespace sidekick
{
    public class CommonRegexes
    {
        public const string STRONG_PASSWORD = "^.*(?=.*\\d)(?=.*[!@#$%^&+=]).*$";
        public const string SHORT_DATE = "^\\d{1,2}\\/\\d{1,2}\\/(19|20)\\d{2}$";
        public const string SSN = "^\\d{3}-?\\d{2}-?\\d{4}$";
        public const string PHONE_NUMBER = "^(\\([2-9]\\d{2}\\)|[2-9]\\d{2})-?[2-9]\\d{2}-?\\d{4}$";
        public const string SHORT_PHONE_NUMBER = "^[2-9]\\d{2}-?\\d{4}$";
        public const string AREA_CODE = "^[2-9]\\d{2}$";
        public const string EMAIL = "^.*@.*$";
        public const string STATE_ABBRV = "^[Aa][KkLlRrSsZz]|[Cc][AaOoTt]|[Dd][CcEe]|[Ff][LlMm]|[Gg][AaUu]|[Hh][Ii]|[Ii][AaDdLlNn]|[Kk][SsYy]|[Ll][Aa]|[Mm][AaDdEeHhIiNnOoPpSsTt]|[Nn][CcDdEeHhJjMmVvYy]|[Oo][HhKjRr]|[Pp][AaIiRrWw]|[Ss][CcDd]|[Tt][NnXx]|[Uu][Tt]|[Vv][AaIiTt]|[Ww][AaIiVvYy]$";
        public const string STATE_IA = "^[Ii][Aa]$";
        public const string ZIP_CODE = "^\\d{5}(-\\d{4})?$";
        public const string NOT_DIGITS = "[^\\d]+";
        public const string YEAR = "^20\\d{2}$";
        public const string NUMBER = "\\d+";
        public const string MONEY = "^\\d+(.\\d{1,2})?$";
    }
}

