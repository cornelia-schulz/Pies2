using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pies.API.Entities
{
    public class PieType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int FlavourTypeId { get; set; }
    }
}
