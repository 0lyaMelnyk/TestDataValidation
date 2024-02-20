using System;
using System.Text.RegularExpressions;

namespace TestDataValidation.Validators
{
    internal class PassportValidator : IValidator
    {
        private readonly Regex _regex = new Regex(@"[\p{IsCyrillic}]{2}\d{6}");
        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value mustn't be null");
            }
            if (!_regex.IsMatch(value))
            {
                throw new ArgumentException($"{value} has incorect format");
            }
            return true;
        }
    }
}
