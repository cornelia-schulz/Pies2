using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

        [HttpGet(Name = "GetPieReviewsForPie")]
        public ActionResult<IEnumerable<PieReviewDto>> GetReviewsForPie(Guid pieId)
        {
            if (!_piesRepository.PieExists(pieId))
            {
                return NotFound();
            }

            var reviewsForPiesFromRepo = _piesRepository.GetPieReviews(pieId);
            return Ok(_mapper.Map<IEnumerable<PieReviewDto>>(reviewsForPiesFromRepo));
        }

        [HttpGet("{pieReviewId}", Name="GetPieReviewForPie")]
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

        [HttpPost(Name = "CreatePieReviewForPie")]
        public ActionResult<PieReviewDto> CreatePieReviewForPie(Guid pieId, PieReviewForCreationDto pieReview)
        {
            if (!_piesRepository.PieExists(pieId))
            {
                return NotFound();
            }

            var pieReviewEntity = _mapper.Map<Entities.PieReview>(pieReview);
            _piesRepository.AddPieReview(pieId, pieReviewEntity);
            _piesRepository.Save();

            var pieReviewToReturn = _mapper.Map<PieReviewDto>(pieReviewEntity);
            return CreatedAtRoute("GetPieReviewForPie",
                new { pieId = pieId, pieReviewId = pieReviewToReturn.Id }, pieReviewToReturn);
        }

        [HttpPut("{pieReviewId}")]
        public IActionResult UpdatePieReviewForPie(Guid pieId,
            Guid pieReviewId,
            PieReviewForUpdateDto pieReview)
        {
            if (!_piesRepository.PieExists(pieId))
            {
                return NotFound();
            }

            var reviewForPieFromRepo = _piesRepository.GetPieReview(pieId, pieReviewId);

            if (reviewForPieFromRepo == null)
            {
                var pieReviewToAdd = _mapper.Map<Entities.PieReview>(pieReview);
                pieReviewToAdd.Id = pieReviewId;

                _piesRepository.AddPieReview(pieId, pieReviewToAdd);

                _piesRepository.Save();

                var pieReviewToReturn = _mapper.Map<PieReviewDto>(pieReviewToAdd);

                return CreatedAtRoute("GetPieReviewForPie",
                    new { pieId, pieReviewId = pieReviewToReturn.Id },
                    pieReviewToReturn);
            }

            _mapper.Map(pieReview, reviewForPieFromRepo);

            _piesRepository.UpdatePieReview(reviewForPieFromRepo);

            _piesRepository.Save();

            return NoContent();
        }

        [HttpPatch("{pieReviewId}")]
        public ActionResult PartiallyUpdatePieReviewForPie(Guid pieId,
            Guid pieReviewId,
            JsonPatchDocument<PieReviewForUpdateDto> patchDocument)
        {
            if (!_piesRepository.PieExists(pieId))
            {
                return NotFound();
            }

            var reviewForPieFromRepo = _piesRepository.GetPieReview(pieId, pieReviewId);

            if (reviewForPieFromRepo == null)
            {
                var pieReviewDto = new PieReviewForUpdateDto();
                patchDocument.ApplyTo(pieReviewDto, ModelState);

                if (!TryValidateModel(pieReviewDto))
                {
                    return ValidationProblem(ModelState);
                }

                var pieReviewToAdd = _mapper.Map<Entities.PieReview>(pieReviewDto);
                pieReviewToAdd.Id = pieReviewId;

                _piesRepository.AddPieReview(pieId, pieReviewToAdd);
                _piesRepository.Save();

                var pieReviewToReturn = _mapper.Map<PieReviewDto>(pieReviewToAdd);

                return CreatedAtRoute("GetPieReviewForPie",
                    new { pieId, pieReviewId = pieReviewToReturn.Id },
                    pieReviewToReturn);
            }

            var pieReviewToPatch = _mapper.Map<PieReviewForUpdateDto>(reviewForPieFromRepo);
            patchDocument.ApplyTo(pieReviewToPatch, ModelState);

            if (!TryValidateModel(pieReviewToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(pieReviewToPatch, reviewForPieFromRepo);

            _piesRepository.UpdatePieReview(reviewForPieFromRepo);

            _piesRepository.Save();

            return NoContent();
        }

        [HttpDelete("{pieReviewId}")]
        public ActionResult DeletePieReviewForPie(Guid pieId, Guid pieReviewId)
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

            _piesRepository.DeletePieReview(reviewForPieFromRepo);
            _piesRepository.Save();

            return NoContent();
        }

        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
