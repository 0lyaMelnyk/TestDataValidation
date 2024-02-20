using System;
namespace TestDataValidation.Validators
{
    public class DeviceValidator : IValidator
    {
        public bool Validate(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Value mustn't be null");
            };
            if(!Guid.TryParse(value, out var _)) 
            {
                throw new ArgumentException($"Value can't be parsed into guid {value}");
            }
            return true;
        }
    }
}
