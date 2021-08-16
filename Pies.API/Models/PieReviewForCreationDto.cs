using Pies.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pies.API.Models
{
    [RatingMustBeBetween1and5Atrribute]
    public class PieReviewForCreationDto //: IValidatableObject
    {
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        public int Rating { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(Rating > 5)
        //    {
        //        yield return new ValidationResult(
        //            "The rating should be between 1 and 5",
        //            new[] { "PieReviewForCreationDto" });
        //    }
        //}
    }
}
