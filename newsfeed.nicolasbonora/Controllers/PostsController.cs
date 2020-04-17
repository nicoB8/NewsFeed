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
    public class PostsController : BaseController
    {
        protected readonly IPostService _postService;
        protected readonly IUserService _userService;

        public PostsController(IPostService postService, IUserService userService, IMapper mapper) : base(mapper)
        {
            _postService = postService;
            _userService = userService;
        }

        // GET: api/Posts
        [HttpGet("", Name = "GetAllPosts")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> Get()
        {
            var postEntities = await _postService.Get();
            if (postEntities == null)
                return NotFound();

            var postDTOs = _mapper.Map<IEnumerable<PostDTO>>(postEntities);

            return Ok(postDTOs);
        }

        // GET: api/Posts/5
        [HttpGet("User/{userId}", Name = "Get")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetByUserId(string userId)
        {
            userId = userId.Trim();

            if (userId.Length == 0)
                return BadRequest();

            if (!_userService.ExistsById(userId))
                return NotFound();

            var postEntities = await _postService.GetByUserId(userId);
            if (postEntities == null)
                return NotFound();

            var postDTOs = _mapper.Map<IEnumerable<PostDTO>>(postEntities);

            return Ok(postDTOs);
        }


        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<PostDTO>> Post([FromBody] PostDTO postDTO)
        {
            if (postDTO.ContentHeader == null || postDTO.FeedId == null)
                return BadRequest();

            postDTO.ContentHeader = postDTO.ContentHeader.Trim();
            postDTO.FeedId = postDTO.FeedId.Trim();

            var postEntity = _mapper.Map<Post>(postDTO);

            var addedPostEntity = await _postService.Post(postEntity);
            if (addedPostEntity == null)
                return Conflict();

            var addedPostDTO = _mapper.Map<PostDTO>(addedPostEntity);

            return Ok(addedPostDTO);
        }
    }
}
