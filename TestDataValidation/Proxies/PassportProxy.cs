using TestDataValidation.Validators;

namespace TestDataValidation.Proxies
{
    public class PassportValidatorProxy : IValidator
    {
        private readonly PassportValidator validator = new PassportValidator();
        private readonly IDCardValidator cardValidator = new IDCardValidator();
        public bool Validate(string value)
        {
            bool isValid;
            if (int.TryParse(value, out _))
            {
                isValid = cardValidator.Validate(value);
            }
            else
            {
                isValid = validator.Validate(value);
            }
            return isValid;
        }
    }
}
