﻿using Pies.API.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pies.API.Models
{
    [RatingMustBeBetween1and5Atrribute(ErrorMessage = "The rating should be between 1 and 5")]
    public abstract class PieReviewForManipulationDto
    {
        public DateTimeOffset DateCreated { get; set; }
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "You should enter a description")]
        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
