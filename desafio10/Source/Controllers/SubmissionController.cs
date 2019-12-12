using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _mapper = mapper;
            _submissionService = service;
        }

        // GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if ((challengeId == null && accelerationId == null))
            {
                return NoContent();
            }

            ICollection<Submission> submissions = _submissionService.FindByChallengeIdAndAccelerationId(challengeId.GetValueOrDefault(), accelerationId.GetValueOrDefault());

            return Ok(_mapper.Map<List<SubmissionDTO>>(submissions));
        }

        // GET api/submission/higherScore
        [HttpGet("{higherScore}")]
        public ActionResult<decimal> GetHigherScore(int? challengeId)
        {
            if (challengeId == null)
            {
                return NoContent();
            }

            return Ok(_submissionService.FindHigherScoreByChallengeId(challengeId.GetValueOrDefault()));
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            return Ok(_mapper.Map<SubmissionDTO>(_submissionService.Save(_mapper.Map<Submission>(value))));
        }

    }
}
