using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChallengeService _challengeService;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            _mapper = mapper;
            _challengeService = service;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId == null && userId == null)
            {
                return NoContent();
            }

            ICollection<Models.Challenge> challenges;

            challenges = _challengeService.FindByAccelerationIdAndUserId(accelerationId.GetValueOrDefault(), userId.GetValueOrDefault());

            return Ok(_mapper.Map<List<ChallengeDTO>>(challenges));
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            return Ok(_mapper.Map<ChallengeDTO>(_challengeService.Save(_mapper.Map<Models.Challenge>(value))));
        }
    }
}