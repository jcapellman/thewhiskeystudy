using System.Text;

namespace thewhiskeystudy.utils.jsonbuilder
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var commandLineArguments = CommandLineParser.ParserArgs<CommandLineArguments>(args);
            
            new FileParser().ParseFile(commandLineArguments.InputFile, commandLineArguments.OutputToJSONFile);
        }
    }
}