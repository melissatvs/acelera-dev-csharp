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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _userService = service;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            if ((accelerationName == null && companyId == null)||
                (accelerationName != null && companyId != null))
            {
                return NoContent();
            }

            ICollection<User> users;

            if (accelerationName != null)
            {
                users = _userService.FindByAccelerationName(accelerationName);
            }
            else
            {
                users = _userService.FindByCompanyId(companyId.GetValueOrDefault());
            }

            return Ok(_mapper.Map<List<UserDTO>>(users));
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            return Ok(_mapper.Map<UserDTO>(_userService.FindById(id)));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            return Ok(_mapper.Map<UserDTO>(_userService.Save(_mapper.Map<User>(value))));
        }

    }
}
