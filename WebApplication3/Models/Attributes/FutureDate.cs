using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Attributes
{
    /// <summary>
    /// Validates that a DateTime value is not in the future.
    /// </summary>
    public class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
        {
            // Default error message if none is provided
            ErrorMessage = "You cannot set a future date.";
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            // Null values should be handled by [Required] attribute
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // Attempt to parse the value as DateTime
            if (value is DateTime dateValue)
            {
                if (dateValue.Date > DateTime.Now.Date)
                {
                    // Return error with the property name for client-side binding
                    return new ValidationResult(
                        ErrorMessage,
                        new[] { validationContext.MemberName! });
                }

                return ValidationResult.Success;
            }

            // Handle DateOnly for .NET 6+
            if (value is DateOnly dateOnlyValue)
            {
                if (dateOnlyValue > DateOnly.FromDateTime(DateTime.Now))
                {
                    return new ValidationResult(
                        ErrorMessage,
                        new[] { validationContext.MemberName! });
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid date format.");
        }
    }
}