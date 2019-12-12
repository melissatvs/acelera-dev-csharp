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
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _mapper = mapper;
            _companyService = service;
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId == null && userId == null)||
                (accelerationId != null && userId != null))
            {
                return NoContent();
            }

            ICollection<Company> companies;

            if (accelerationId != null)
            {
                companies = _companyService.FindByAccelerationId(accelerationId.GetValueOrDefault());
            }
            else
            {
                companies = _companyService.FindByUserId(userId.GetValueOrDefault());
            }

            return Ok(_mapper.Map<List<CompanyDTO>>(companies));
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(_mapper.Map<CompanyDTO>(_companyService.FindById(id)));
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            return Ok(_mapper.Map<CompanyDTO>(_companyService.Save(_mapper.Map<Company>(value))));
        }
    }

    
}
