using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpier
{
    public static class CommandLineOptions
    {
        internal delegate Task<int> Handler(
            string directoryOrFile,
            bool check,
            bool fast,
            bool skipWrite,
            CancellationToken cancellationToken
        );

        public static RootCommand Create()
        {
            var rootCommand = new RootCommand
            {
                new Argument<string>(
                    "directoryOrFile"
                )
                {
                    Arity = ArgumentArity.ZeroOrOne,
                    Description = "A path to a directory containing files to format or a file to format. If a path is not specified the current directory is used"
                }.LegalFilePathsOnly(),
                new Option(
                    new[] { "--check" },
                    "Check that files are formatted. Will not write any changes."
                ),
                new Option(
                    new[] { "--fast" },
                    "Skip comparing syntax tree of formatted file to original file to validate changes."
                ),
                new Option(
                    new[] { "--skip-write" },
                    "Skip writing changes. Generally used for testing to ensure csharpier doesn't throw any errors or cause syntax tree validation failures."
                )
            };

            rootCommand.Description = "csharpier";

            return rootCommand;
        }
    }
}
