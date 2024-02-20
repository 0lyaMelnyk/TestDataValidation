using System;

namespace TestDataValidation.Validators
{
    public class TaxNumberValidator : IValidator
    {
        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value mustn't be null");
            }
            if (!int.TryParse(value, out var _))
            {
                throw new ArgumentException("Tax Number Identity should only contains numbers");
            }
            if (value?.Trim().Length != 10)
            {
                throw new ArgumentException("Tax Number Identity should contains 10 chars");
            }
            return true;
        }
    }
}
