using System;
using System.CommandLine;
using System.Text;

namespace TestDataValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RootCommand rootCommand = new RootCommand();
            rootCommand.AddCommand(SubCommandCreator.CreateNewSubcommand("passport", "Validate passport"));
            rootCommand.AddCommand(SubCommandCreator.CreateNewSubcommand("rnokpp", "Validate rnokpp"));
            rootCommand.AddCommand(SubCommandCreator.CreateNewSubcommand("birthday", "Validate birthday"));
            rootCommand.AddCommand(SubCommandCreator.CreateNewSubcommand("deviceUuid", "Validate device uuid"));
            rootCommand.InvokeAsync(args);
        }
    }
}
