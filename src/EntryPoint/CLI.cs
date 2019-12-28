using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using CommandLine;

namespace PPhoria.Grid.EntryPoint
{
    public class Cli
    {
        public enum OptionsType
        {
            Run,
            Pass
        }

        public abstract class BaseOptions
        {
            public abstract OptionsType OptionType { get; }
        }

        public static class Run
        {
            [Verb("run", HelpText = "")]
            public class Options : BaseOptions
            {
                [Option('s', "speed")] public virtual int Speed { get; set; } = 1;

                public sealed class DefaultOptions : Options
                {
                    private DefaultOptions()
                    {
                    }

                    public static DefaultOptions Instance => Nested.NestedInstance;

                    private class Nested
                    {
                        static Nested()
                        {
                        }

                        internal static readonly DefaultOptions NestedInstance = new DefaultOptions();
                    }

                    public override int Speed
                    {
                        get => 1;
                        set { }
                    }
                }

                public override OptionsType OptionType => OptionsType.Run;
            }

            public static int Execute(Options opts)
            {
                RootKernel.Instance.Configure(opts);
                var application = RootKernel.Instance.Get<Application>();
                RootKernel.Instance.Get<BootstrapperBase>();
                return application.Run();
            }
        }

        public static class Pass
        {
            [Verb("pass", HelpText = "")]
            public class Options : BaseOptions
            {
                public override OptionsType OptionType => OptionsType.Pass;
            }

            public static int Execute(Options opts)
            {
                return 1;
            }
        }

        public static class NotParsed
        {
            public static int Execute(IEnumerable<Error> errors)
            {
                return -1;
            }
        }
    }
}