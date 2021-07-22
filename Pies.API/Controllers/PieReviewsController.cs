using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pies.API.Models;
using Pies.API.Services;
using System;
using System.Collections.Generic;

namespace Pies.API.Controllers
{
    [ApiController]
    [Route("api/v1/pies/{pieId}/piereviews")]
    public class PieReviewsController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;
        private readonly IMapper _mapper;

        public PieReviewsController(IPiesRepository piesRepository,
            IMapper mapper)
        {
            _piesRepository = piesRepository ?? throw new ArgumentNullException(nameof(piesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PieReviewDto>> GetReviewsForPie(Guid pieId)
        {
            if (!_piesRepository.PieExists(pieId))
            {
                return NotFound();
            }

            var reviewsForPiesFromRepo = _piesRepository.GetPieReviews(pieId);
            return Ok(_mapper.Map<IEnumerable<PieReviewDto>>(reviewsForPiesFromRepo));
        }

        [HttpGet("{pieReviewId}")]
        public ActionResult<PieReviewDto> GetReviewForPie(Guid pieId, Guid pieReviewId)
        {
            if (!_piesRepository.PieExists(pieId))
            {
                return NotFound();
            }

            var reviewForPieFromRepo = _piesRepository.GetPieReview(pieId, pieReviewId);

            if (reviewForPieFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PieReviewDto>(reviewForPieFromRepo));
        }
    }
}
