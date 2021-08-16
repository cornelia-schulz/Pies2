using Pies.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Pies.API.ValidationAttributes
{
    public class RatingMustBeBetween1and5Atrribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var review = (PieReviewForCreationDto)validationContext.ObjectInstance;
            if (review.Rating > 5 || review.Rating < 1)
            {
                 return new ValidationResult(ErrorMessage,
                    new[] { "PieReviewForCreationDto" });
            }

            return ValidationResult.Success;
        }
    }
}
