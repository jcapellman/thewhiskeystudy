namespace thewhiskeystudy.lib.Common
{
    public static class Constants
    {
        

        public const string FILE_JSON_DBFILENAME = "whiskeydb.json";
        public const string FILE_XLSX_DBFILENAME = "Whiskey DB.xlsx";

        public const string FILE_TOKEN_FILENAME = "token.key";

        public const string FILE_NLOG_CONFIG_FILENAME = "nlog.config";

        public const string URL_RESTSERVICE = "http://thewhiskeystudy.com/api/";

        public const string HTTP_HEADER_TOKEN = "Token";

        public const string REPORT_NAME_TOP_BARGAINS = "Top Bargains";
        public const string REPORT_DESCRIPTION_TOP_BARGAINS = "Top rated and readily available less than $60 bottles.";
        public const double TOP_BARGAINS_RATING_CUTOFF = 5;

        public const string REPORT_NAME_TOP_RATED = "Top Rated";
        public const string REPORT_DESCRIPTION_TOP_RATED = "Top rated whiskey if money was no object.";
        public const double TOP_RATED_RATING_CUTOFF = 8;
    }
}