﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Entities;
using Pies.API.Helpers;
using Pies.API.Models;
using Pies.API.ResourceParameters;
using Pies.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetPies([FromQuery] PiesResourceParameters piesResourceParameters)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<PieDto, Pie>(piesResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            var piesFromRepo = _piesRepository.GetPies(piesResourceParameters);

            var paginationMetadata = new
            {
                totalCount = piesFromRepo.TotalCount,
                pageSize = piesFromRepo.PageSize,
                currentPage = piesFromRepo.CurrentPage,
                totalPages = piesFromRepo.TotalPages
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            var links = CreateLinksForPies(piesResourceParameters,
                piesFromRepo.HasNext,
                piesFromRepo.HasPrevious);

            var shapedPies = _mapper.Map<IEnumerable<PieDto>>(piesFromRepo)
                .ShapeData(piesResourceParameters.Fields);

            var shapedPiesWithLinks = shapedPies.Select(pie =>
            {
                var pieAsDictionary = pie as IDictionary<string, object>;
                var pieLinks = CreateLinksForPie((Guid)pieAsDictionary["Id"], null);
                pieAsDictionary.Add("links", pieLinks);
                return pieAsDictionary;
            });

            var linkedCollectionResource = new
            {
                value = shapedPiesWithLinks,
                links
            };

            return Ok(linkedCollectionResource);
        }

        [HttpGet("{pieId}", Name="GetPie")]
        public IActionResult GetPie(Guid pieId, string fields)
        {
            var pieFromRepo = _piesRepository.GetPie(pieId);

            if (pieFromRepo == null)
            {
                return NotFound();
            }

            var links = CreateLinksForPie(pieId, fields);
            var linkedResourceToReturn =
                _mapper.Map<PieDto>(pieFromRepo).ShapeData(fields)
                as IDictionary<string, object>;

            linkedResourceToReturn.Add("links", links);

            return Ok(linkedResourceToReturn);
        }

        [HttpPost(Name = "CreatePie")]
        public ActionResult<PieDto> CreatePie(PieForCreationDto pie)
        {
            var pieEntity = _mapper.Map<Entities.Pie>(pie);
            _piesRepository.AddPie(pieEntity);
            _piesRepository.Save();

            var pieToReturn = _mapper.Map<PieDto>(pieEntity);

            var links = CreateLinksForPie(pieToReturn.Id, null);
            var linkedResourcesToReturn = pieToReturn.ShapeData(null)
                as IDictionary<string, object>;
            linkedResourcesToReturn.Add("links", links);

            return CreatedAtRoute("GetPie",
                new { pieId = linkedResourcesToReturn["Id"] },
                linkedResourcesToReturn);
        }

        [HttpOptions]
        public IActionResult GetPiesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }

        [HttpDelete("{pieId}", Name = "DeletePie")]
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
                           fields = piesResourceParameters.Fields,
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
                            fields = piesResourceParameters.Fields,
                            orderBy = piesResourceParameters.OrderBy,
                            pageNumber = piesResourceParameters.PageNumber + 1,
                            pageSize = piesResourceParameters.PageSize,
                            name = piesResourceParameters.Name,
                            searchQuery = piesResourceParameters.SearchQuery
                        });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetPies",
                        new
                        {
                            fields = piesResourceParameters.Fields,
                            orderBy = piesResourceParameters.OrderBy,
                            pageNumber = piesResourceParameters.PageNumber,
                            pageSize = piesResourceParameters.PageSize,
                            name = piesResourceParameters.Name,
                            searchQuery = piesResourceParameters.SearchQuery
                        });
            }
        }

        private IEnumerable<LinkDto> CreateLinksForPie(Guid pieId, string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                    new LinkDto(Url.Link("GetPie", new { pieId }),
                    "self",
                    "GET"));
            }
            else
            {
                links.Add(
                    new LinkDto(Url.Link("GetPie", new { pieId, fields }),
                    "self",
                    "GET"));
            }

            links.Add(
                new LinkDto(Url.Link("DeletePie", new { pieId }),
                "delete_pie",
                "DELETE"));

            links.Add(
                new LinkDto(Url.Link("CreatePieReviewForPie", new { pieId }),
                "create_pie_review_for_pie",
                "POST"));

            links.Add(
                new LinkDto(Url.Link("GetPieReviewsForPie", new { pieId }),
                "pie_reviews",
                "GET"));

            return links;
        }

        private IEnumerable<LinkDto> CreateLinksForPies(
            PiesResourceParameters piesResourceParameters,
            bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(CreatePiesResourceUri(piesResourceParameters, ResourceUriType.Current),
                "self",
                "GET"));

            if (hasNext)
            {
                links.Add(
                    new LinkDto(CreatePiesResourceUri(
                        piesResourceParameters, ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreatePiesResourceUri(
                        piesResourceParameters, ResourceUriType.PreviousPage),
                        "previousPage",
                        "GET"));
            }

            return links;
        }
    }
}
