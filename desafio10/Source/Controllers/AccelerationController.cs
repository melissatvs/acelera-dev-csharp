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
    public class AccelerationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccelerationService _accelerationService;

        public AccelerationController(IAccelerationService service, IMapper mapper)
        {
            _mapper = mapper;
            _accelerationService = service;
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == null)
            {
                return NoContent();
            }

            ICollection<Acceleration> accelerations = _accelerationService.FindByCompanyId(companyId.GetValueOrDefault());
            
            return Ok(_mapper.Map<List<AccelerationDTO>>(accelerations));
        }

        // GET api/acceleration/{id}
        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            return Ok(_mapper.Map<AccelerationDTO>(_accelerationService.FindById(id)));
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            return Ok(_mapper.Map<AccelerationDTO>(_accelerationService.Save(_mapper.Map<Acceleration>(value))));
        }
    }
}
