using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Entities;
using Pies.API.Helpers;
using Pies.API.Models;
using Pies.API.ResourceParameters;
using Pies.API.Services;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pies.API.Controllers
{
    [ApiController]
    [Route("api/v1/pies")]
    public class PiesController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;

        public PiesController(IPiesRepository piesRepository,
            IMapper mapper, IPropertyMappingService propertyMappingService)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        }

        [HttpGet(Name = "GetPies")]
        [HttpHead]
        // get pies and if query string is passed in then filter by query string
        public ActionResult<IEnumerable<PieDto>> GetPies([FromQuery] PiesResourceParameters piesResourceParameters)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<PieDto, Pie>(piesResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            var piesFromRepo = _piesRepository.GetPies(piesResourceParameters);
            var previousPageLink = piesFromRepo.HasPrevious ?
                CreatePiesResourceUri(piesResourceParameters,
                ResourceUriType.PreviousPage) : null;

            var nextPageLink = piesFromRepo.HasNext ?
                CreatePiesResourceUri(piesResourceParameters,
                ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = piesFromRepo.TotalCount,
                pageSize = piesFromRepo.PageSize,
                currentPage = piesFromRepo.CurrentPage,
                totalPages = piesFromRepo.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

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

        [HttpDelete("{pieId}")]
        public ActionResult DeletePie(Guid pieId)
        {
            var pieFromRepo = _piesRepository.GetPie(pieId);

            if (pieFromRepo == null)
            {
                return NotFound();
            }

            _piesRepository.DeletePie(pieFromRepo);
            _piesRepository.Save();

            return NoContent();
        }


        private string CreatePiesResourceUri(
            PiesResourceParameters piesResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetPies",
                       new
                       {
                           orderBy = piesResourceParameters.OrderBy,
                           pageNumber = piesResourceParameters.PageNumber - 1,
                           pageSize = piesResourceParameters.PageSize,
                           name = piesResourceParameters.Name,
                           searchQuery = piesResourceParameters.SearchQuery
                       });
                case ResourceUriType.NextPage:
                    return Url.Link("GetPies",
                        new
                        {
                            orderBy = piesResourceParameters.OrderBy,
                            pageNumber = piesResourceParameters.PageNumber + 1,
                            pageSize = piesResourceParameters.PageSize,
                            name = piesResourceParameters.Name,
                            searchQuery = piesResourceParameters.SearchQuery
                        });
                default:
                    return Url.Link("GetPies",
                        new
                        {
                            orderBy = piesResourceParameters.OrderBy,
                            pageNumber = piesResourceParameters.PageNumber,
                            pageSize = piesResourceParameters.PageSize,
                            name = piesResourceParameters.Name,
                            searchQuery = piesResourceParameters.SearchQuery
                        });
            }
        }
    }
}
