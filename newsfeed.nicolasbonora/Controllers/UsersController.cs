using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsfeed.nicolasbonora.dtos;
using newsfeed.nicolasbonora.entities;
using newsfeed.nicolasbonora.services;

namespace newsfeed.nicolasbonora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        protected readonly IUserService _userService;
        public UsersController(IUserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var userEntities = await _userService.Get();
            return Ok(_mapper.Map<IEnumerable<UserDTO>>(userEntities));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDTO)
        {
            if (userDTO.Email == null || userDTO.Name == null)
                return BadRequest();

            userDTO.Email = userDTO.Email.Trim();
            userDTO.Name = userDTO.Name.Trim();

            var userEntity = _mapper.Map<User>(userDTO);

            var addedUserEntity = await _userService.Post(userEntity);
            if (addedUserEntity == null)
                return Conflict();

            var addedUserDTO = _mapper.Map<UserDTO>(addedUserEntity);

            return Ok(addedUserDTO);
        }
    }
}
