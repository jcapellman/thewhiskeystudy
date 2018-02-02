using CommandLine;

using thewhiskeystudy.lib.Common;

namespace thewhiskeystudy.utils.jsonbuilder
{
    public class CommandLineArguments
    {
        [Option('i', "input", Required = false, DefaultValue = Constants.FILE_XLSX_DBFILENAME, HelpText = "Input file for XLSX Database")]
        public string InputFile { get; set; }
        
        [Option('o', "output", DefaultValue = false, Required = false, HelpText = "Output to JSON DB instead of uploading to REST Service")]
        public bool OutputToJSONFile { get; set; }
    }
}