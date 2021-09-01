using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.ResourceParameters
{
    public class PiesResourceParameters
    {
        const int maxPageSize = 20;
        public string Name { get; set; }
        public string SearchQuery { get; set; }
        // provide default values
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; } = "Name";
    }
}
