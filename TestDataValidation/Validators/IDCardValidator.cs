using System;
namespace TestDataValidation.Validators
{
    internal class IDCardValidator : IValidator
    {
        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value mustn't be null");
            }
            if (!int.TryParse(value, out int _))
            {
                throw new ArgumentException("ID card number should be a number");
            }
            if (value.Trim().Length != 9)
            {
                throw new ArgumentException("ID card number should contains 9 chars");
            }
            //TODO: check if value already exists in the DB
            return true;
        }
    }
}
