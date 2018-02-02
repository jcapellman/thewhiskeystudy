using System.Text;

using CommandLine;

namespace thewhiskeystudy.utils.jsonbuilder
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var commandLineArguments = new CommandLineArguments();

            Parser.Default.ParseArguments(args, commandLineArguments);
            
            new FileParser().ParseFile(commandLineArguments.InputFile, commandLineArguments.OutputToJSONFile);
        }
    }
}