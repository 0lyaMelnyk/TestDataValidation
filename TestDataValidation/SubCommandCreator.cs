using System;
using System.CommandLine;
using TestDataValidation.Proxies;
using TestDataValidation.Validators;

namespace TestDataValidation
{
    public static class SubCommandCreator
    {
        public static Command CreateNewSubcommand(string name, string description)
        {
            var subCommand = new Command(name, description);
            var valueArgument = new Argument<string>(name: "value");
            subCommand.AddArgument(valueArgument);
            subCommand.SetHandler(value =>
            {
                HandleSubCommand(GetValidatorByType(name), value);
            }, valueArgument);
            return subCommand;
        }
        private static IValidator GetValidatorByType(string command)
        {
            return command switch
            {
                "passport" => new PassportValidatorProxy(),
                "rnokpp" => new TaxNumberValidator(),
                "birthday" => new DateValidator(),
                "deviceUuid" => new DeviceValidator(),
                _ => null,
            };
        }
        static void HandleSubCommand(IValidator validator, string value)
        {
            try
            {
                Console.WriteLine(validator?.Validate(value));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine(false);
            }
        }
    }
}
