using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pies.API.Entities
{
    public class Pie
    {
        [Key]       
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("PieTypeId")]
        public PieType PieType { get; set; }
        public Guid PieTypeId { get; set; }
        public Guid UserId { get; set; }
        public int ShopId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public ICollection<PieReview> PieReviews { get; set; }
            = new List<PieReview>();
    }
}
