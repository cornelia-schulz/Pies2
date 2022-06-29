using Microsoft.AspNetCore.Mvc;

namespace Pies.API.ResourceParameters
{
    public class ShopResourceParameters : DefaultResourceParameters
    {
        [BindProperty(Name = "ne_lat", SupportsGet = true)]
        public double NorthEastLat { get; set; }

        [BindProperty(Name = "ne_lng", SupportsGet = true)]
        public double NorthEastLng { get; set; }

        [BindProperty(Name = "sw_lat", SupportsGet = true)]
        public double SouthWestLat { get; set; }

        [BindProperty(Name = "sw_lng", SupportsGet = true)]
        public double SouthWestLng { get; set; }
    }
}
