using System;
using CommandLine;

namespace PPhoria.Grid.EntryPoint
{
    /// <summary>
    /// Initialization code to parse args
    /// </summary>
    public partial class App
    {
        private static readonly Lazy<Parser> ParserLazy = new Lazy<Parser>(delegate
        {
            return new Parser(
                delegate (ParserSettings settings) { settings.EnableDashDash = true; }
            );
        });

        private static Parser ArgsParser => ParserLazy.Value;

        [STAThread]
        public static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                return ArgsParser.ParseArguments<Cli.Run.Options, Cli.Pass.Options>(args)
                    .MapResult(
                        (Cli.Run.Options opts) => Cli.Run.Execute(opts),
                        (Cli.Pass.Options opts) => Cli.Pass.Execute(opts),
                        Cli.NotParsed.Execute
                    );
            }

            return Cli.Run.Execute(Cli.Run.Options.DefaultOptions.Instance);
        }
    }
}