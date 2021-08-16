using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Models;
using Pies.API.ResourceParameters;
using Pies.API.Services;
using System;
using System.Collections.Generic;

namespace Pies.API.Controllers
{
    [ApiController]
    [Route("api/v1/pies")]
    public class PiesController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;

        public PiesController(IPiesRepository piesRepository,
            IMapper mapper)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead]
        // get pies and if query string is passed in then filter by query string
        public ActionResult<IEnumerable<PieDto>> GetPies([FromQuery] PiesResourceParameters piesResourceParameters)
        {
            var piesFromRepo = _piesRepository.GetPies(piesResourceParameters);
            var pies = new List<PieDto>();

            return Ok(_mapper.Map<IEnumerable<PieDto>>(piesFromRepo));
        }

        [HttpGet("{pieId}", Name="GetPie")]
        public IActionResult GetPie(Guid pieId)
        {
            var pieFromRepo = _piesRepository.GetPie(pieId);

            if (pieFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PieDto>(pieFromRepo));
        }

        [HttpPost]
        public ActionResult<PieDto> CreatePie(PieForCreationDto pie)
        {
            var pieEntity = _mapper.Map<Entities.Pie>(pie);
            _piesRepository.AddPie(pieEntity);
            _piesRepository.Save();

            var pieToReturn = _mapper.Map<PieDto>(pieEntity);
            return CreatedAtRoute("GetPie",
                new { pieId = pieToReturn.Id },
                pieToReturn);
        }

        [HttpOptions]
        public IActionResult GetPiesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }
    }
}
