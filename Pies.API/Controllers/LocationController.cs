using AutoMapper;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pies.API.Controllers
{
    [ApiController]
    [Route("api/v1/shops/{shopId}/locations")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Public)]
    [HttpCacheValidation(MustRevalidate = true)]
    public class LocationController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;

        public LocationController(IPiesRepository piesRepository,
            IMapper mapper)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet]
    }
}
