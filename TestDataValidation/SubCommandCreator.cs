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
            var valueArgument = new Argument<string>(name: "value", "some description");
            subCommand.AddArgument(valueArgument);
            subCommand.SetHandler(value =>
            {
                HandleSubCommand(GetValidatorByType(name), value);
            }, valueArgument);
            return subCommand;
        }
        private static IValidator GetValidatorByType(string command)
        {
            switch(command)
            {
                case "passport": return new PassportValidatorProxy();
                case "rnokpp": return new TaxNumberValidator();
                case "birthday": return new DateValidator();
                case "deviceUuid": return new DeviceValidator();
                default : return null;
            }
        }
        static void HandleSubCommand(IValidator validator, string value)
        {
            try
            {
                Console.WriteLine(validator.Validate(value));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine(false);
            }
        }
    }
}
