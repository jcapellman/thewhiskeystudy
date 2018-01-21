using System.Text;

using thewhiskeystudy.lib.Common;

namespace thewhiskeystudy.utils.jsonbuilder
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var inputFileName = Constants.FILE_XLSX_DBFILENAME;
            var outputFileName = Constants.FILE_JSON_DBFILENAME;

            if (args.Length == 2)
            {
                inputFileName = args[0];
                outputFileName = args[1];
            }            

            new FileParser().ParseFile(inputFileName, outputFileName);
        }
    }
}