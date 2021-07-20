using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Models;
using Pies.API.Services;
using System;
using System.Collections.Generic;

namespace Pies.API.Controllers
{
    [ApiController]
    // set the base route at the top, so you repeat yourself less
    [Route("api/v1/pietypes")]
    public class PieTypesController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;

        public PieTypesController(IPiesRepository piesRepository,
            IMapper mapper)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // simply gets the pie types from the base route at the top ("api/v1/pietypes")
        [HttpGet()]
        public ActionResult<IEnumerable<PieTypeDto>> GetPieTypes()
        {
            var pieTypesFromRepo = _piesRepository.GetPieTypes();
            var pieTypes = new List<PieTypeDto>();

            return Ok(_mapper.Map<IEnumerable<PieTypeDto>>(pieTypesFromRepo));
        }

        [HttpGet("{pieTypeId}")]
        public IActionResult GetPieType(Guid pieTypeId)
        {
            var pieTypeFromRepo = _piesRepository.GetPieType(pieTypeId);

            if (pieTypeFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PieTypeDto>(pieTypeFromRepo));
        }
    }
}
