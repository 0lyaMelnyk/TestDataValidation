using System;
using System.Globalization;

namespace TestDataValidation.Validators
{
    public class DateValidator : IValidator
    {
        public bool Validate(string value)
        {
            CultureInfo ua = new CultureInfo("ua-UA");
            if (!DateTime.TryParseExact(value, "dd.MM.yyyy", ua, DateTimeStyles.None, out DateTime _))
            {
                throw new ArgumentException($"Wrong date format {value}");
            }
            //TODO: here can be validation for age threshold if it's needed
            return true;
        }
    }
}
