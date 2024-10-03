using System.ComponentModel.DataAnnotations;

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime birthday)
        {
            if (birthday < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Birthday must be a past date.");
            }
        }
        return new ValidationResult("Invalid date format.");
    }
}