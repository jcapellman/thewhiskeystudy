using thewhiskeystudy.lib.Common;

namespace thewhiskeystudy.utils.jsonbuilder
{
    public class CommandLineArguments
    {        
        public string InputFile { get; set; }

        public bool OutputToJSONFile { get; set; }

        public CommandLineArguments()
        {
            InputFile = Constants.FILE_XLSX_DBFILENAME;
            OutputToJSONFile = false;
        }
    }
}