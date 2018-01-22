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
            
            if (args.Length == 1)
            {
                inputFileName = args[0];
            }            

            new FileParser().ParseFile(inputFileName);
        }
    }
}