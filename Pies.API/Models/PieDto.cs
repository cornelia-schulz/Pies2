using System;

namespace Pies.API.Models
{
    public class PieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PieTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid ShopId { get; set; }
        public int Age { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
