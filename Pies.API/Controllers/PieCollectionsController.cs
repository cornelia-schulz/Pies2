using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Helpers;
using Pies.API.Models;
using Pies.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pies.API.Controllers
{
    [ApiController]
    [Route("api/v1/piecollections")]
    public class PieCollectionsController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;

        public PieCollectionsController(IPiesRepository piesRepository,
            IMapper mapper)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name ="GetPieCollection")]
        public IActionResult GetPieCollection(
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var pieEntities = _piesRepository.GetPies(ids);

            if (ids.Count() != pieEntities.Count())
            {
                return NotFound();
            }

            var piesToReturn = _mapper.Map<IEnumerable<PieDto>>(pieEntities);

            return Ok(piesToReturn);
        }

        [HttpPost]
        public ActionResult<IEnumerable<PieDto>> CreatePieCollection(IEnumerable<PieForCreationDto> pieCollection)
        {
            var pieEntities = _mapper.Map<IEnumerable<Entities.Pie>>(pieCollection);
            foreach (var pie in pieEntities)
            {
                _piesRepository.AddPie(pie);
            }

            _piesRepository.Save();

            var pieCollectionToReturn = _mapper.Map<IEnumerable<PieDto>>(pieEntities);
            var idsAsString = string.Join(",", pieCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetPieCollection",
                new { ids = idsAsString },
                pieCollectionToReturn);
        }
    }
}
