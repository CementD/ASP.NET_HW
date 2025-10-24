using System.ComponentModel.DataAnnotations;

namespace SmartTripApp.Models.Attributes
{
    public class DateNotEarlierThat : ValidationAttribute
    {
        private readonly DateOnly? _minDate;

        private readonly string _comparisonField;

        public DateNotEarlierThat(string minDate)
        {
            if (minDate.Equals("today", StringComparison.OrdinalIgnoreCase))
            {
                _minDate = DateOnly.FromDateTime(DateTime.Today);
            }
            else if (DateOnly.TryParse(minDate, out var parsed))
            {
                _minDate = parsed;
            }
            else
            {
                _minDate = null;
                _comparisonField = minDate;
            }
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            DateOnly dateValue;
            DateOnly comparisonValue;

            if (value is DateOnly d)
                dateValue = d;
            else if (value is DateTime dt)
                dateValue = DateOnly.FromDateTime(dt);
            else
                return new ValidationResult("Invalide value type for MinDate.");

            if (_minDate == null)
            {
                var property = validationContext.ObjectType.GetProperty(_comparisonField);
                if (property == null)
                    return new ValidationResult($"Unknown property: {_comparisonField}");
                comparisonValue = (DateOnly?)property.GetValue(validationContext.ObjectInstance) ?? DateOnly.FromDateTime(DateTime.Today);
            }
            else
            {
                comparisonValue = _minDate.Value;
            }

            if (dateValue < comparisonValue)
            {
                var errorMsg = ErrorMessage ?? $"The date cannot be earlier than {comparisonValue:yyyy-MM-dd}.";
                return new ValidationResult(errorMsg);
            }

            return ValidationResult.Success;
        }
    }
}
