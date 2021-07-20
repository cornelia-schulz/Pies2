using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Entities
{
    public class PieReviewVariableType
    {
        public Guid Id { get; set; }
        public string PieReviewVariableTypeName { get; set; }
        public Guid FlavourTypeId { get; set; }
    }
}
