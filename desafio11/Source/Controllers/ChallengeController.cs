using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService service;
        private IMapper mapper;

        public ChallengeController(IChallengeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {            
            if (accelerationId.HasValue && userId.HasValue)
                return Ok(this.service.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value).
                        Select(x => mapper.Map<ChallengeDTO>(x)).
                        ToList());
            else
                return NoContent();
        }

        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(mapper.Map<ChallengeDTO>(service.Save(mapper.Map<Models.Challenge>(value))));
        }
     
    }
}
