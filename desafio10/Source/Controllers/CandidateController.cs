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
    public class CandidateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _mapper = mapper;
            _candidateService = service;
        }

        // GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if ((companyId == null && accelerationId == null) ||
                (companyId != null && accelerationId != null))
            {
                return NoContent();
            }

            ICollection<Candidate> candidates;

            if (companyId != null)
            {
                candidates = _candidateService.FindByCompanyId(companyId.GetValueOrDefault());
            }
            else
            {
                candidates = _candidateService.FindByAccelerationId(accelerationId.GetValueOrDefault());
            }
            

            return Ok(_mapper.Map<List<CandidateDTO>>(candidates));
        }

        // GET api/candidate/{userId}/{accelerationId}/{companyId}
        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.FindById(userId, accelerationId, companyId)));
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.Save(_mapper.Map<Candidate>(value))));
        }
    }
}
