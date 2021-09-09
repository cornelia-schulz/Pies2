
using AutoMapper;
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
    [Route("api/v1/shops")]
    public class ShopController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;

        public ShopController(IPiesRepository piesRepository,
            IMapper mapper, IPropertyMappingService propertyMappingService)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        }

        [HttpGet(Name = "GetShops")]
        [HttpHead]
        public IActionResult GetShops([FromQuery] PiesResourceParameters piesResourceParameters)
        {
            if (!_propertyMappingService.ValidMappingExistsFor<ShopDto, Shop>(piesResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            var shopsFromRepo = _piesRepository.GetShops(piesResourceParameters);

            var paginationMetadata = new
            {
                totalCount = shopsFromRepo.TotalCount,
                pageSize = shopsFromRepo.PageSize,
                currentPage = shopsFromRepo.CurrentPage,
                totalPages = shopsFromRepo.TotalPages
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            var links = CreateLinksForShops(piesResourceParameters,
                shopsFromRepo.HasNext,
                shopsFromRepo.HasPrevious);

            var shapedShops = _mapper.Map<IEnumerable<ShopDto>>(shopsFromRepo)
                .ShapeData(piesResourceParameters.Fields);

            var shapedShopsWithLinks = shapedShops.Select(shop =>
            {
                var shopAsDictionary = shop as IDictionary<string, object>;
                var shopLinks = CreateLinksForShop((Guid)shopAsDictionary["Id"], null);
                shopAsDictionary.Add("links", shopLinks);
                return shopAsDictionary;
            });

            var linkedCollectionResource = new
            {
                value = shapedShopsWithLinks,
                links
            };

            return Ok(linkedCollectionResource);
        }

        private string CreateShopsResourceUri(
            PiesResourceParameters piesResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetShops",
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
                    return Url.Link("GetShops",
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
                    return Url.Link("GetShops",
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

        private IEnumerable<LinkDto> CreateLinksForShop(Guid shopId, string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                    new LinkDto(Url.Link("GetShop", new { shopId }),
                    "self",
                    "GET"));
            }
            else
            {
                links.Add(
                    new LinkDto(Url.Link("GetShop", new { shopId, fields }),
                        "self",
                        "GET"));
            }

            return links;
        }

        private IEnumerable<LinkDto> CreateLinksForShops(
            PiesResourceParameters piesResourceParameters,
            bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(CreateShopsResourceUri(piesResourceParameters, ResourceUriType.Current),
                "self",
                "GET"));

            if (hasNext)
            {
                links.Add(
                    new LinkDto(CreateShopsResourceUri(
                        piesResourceParameters, ResourceUriType.NextPage),
                        "nextPage",
                        "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new LinkDto(CreateShopsResourceUri(
                        piesResourceParameters, ResourceUriType.PreviousPage),
                        "previousPage",
                        "GET"));
            }

            return links;
        }
    }
}
