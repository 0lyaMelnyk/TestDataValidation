using Xunit;
using TestDataValidation;
using System.CommandLine;
using TestDataValidation.Validators;
using TestDataValidation.Proxies;
using System;

namespace DataValidationTests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("rnokpp", "1234567890")]
        [InlineData("passport", "БД123456")]
        [InlineData("passport", "бд654321")]
        [InlineData("passport", "123456789")]
        [InlineData("birthday", "30.01.2001")]
        [InlineData("deviceUuid", "3614435a-8b46-42de-a7b5-bf1d72c4b913")]
        [InlineData("deviceUuid", "B5A648BA-262F-47BF-A0F5-4FDF68AC0C12")]
        public void ShouldReturnTrueIfValueIsCorrect(string command, string value)
        {
            RootCommand rootCommand = new RootCommand();
            rootCommand.AddCommand(SubCommandCreator.CreateNewSubcommand(command, $"Validate {command}"));
            using var consoleOutput = new ConsoleOutput();
            rootCommand.InvokeAsync(new string[] { command, value });
            Assert.Contains(true.ToString(), consoleOutput.GetOuput());
        }

        [Theory]
        [InlineData("FD123456")]
        [InlineData("654321")]
        [InlineData("1234567890")]
        public void ShouldThrowArgumentExceptionWhenValueIsNotValidForPassport(string value)
        {
            PassportValidatorProxy proxy = new PassportValidatorProxy();
            Assert.Throws<ArgumentException>(() => proxy.Validate(value));
        }

        [Theory]
        [InlineData("FD123456")]
        [InlineData("654321")]
        [InlineData("12345678901")]
        public void ShouldThrowArgumentExceptionWhenValueIsNotValidForTaxNumber(string value)
        {
            TaxNumberValidator validator = new TaxNumberValidator();
            Assert.Throws<ArgumentException>(() => validator.Validate(value));
        }

        [Theory]
        [InlineData("not guid")]
        public void ShouldThrowArgumentExceptionWhenValueIsNotValidForDeviceUuid(string value)
        {
            DeviceValidator validator = new DeviceValidator();
            Assert.Throws<ArgumentException>(() => validator.Validate(value));
        }

        [Theory]
        [InlineData("4.9.2")]
        [InlineData("09/08/2009")]
        public void ShouldThrowArgumentExceptionWhenValueIsNotValidForBirthday(string value)
        {
            DateValidator validator = new DateValidator();
            Assert.Throws<ArgumentException>(() => validator.Validate(value));
        }
    }
}
