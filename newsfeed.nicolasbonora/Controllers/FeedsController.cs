﻿using System;
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
    public class FeedsController : BaseController
    {
        protected readonly IFeedService _feedService;
        protected readonly IUserService _userService;

        public FeedsController(IFeedService feedService, IUserService userService, IMapper mapper) : base(mapper)
        {
            _feedService = feedService;
            _userService = userService;
        }

        // GET: api/Feeds/{id}/subscribe/{userId}
        [HttpGet("{id}/subscribe/{userId}", Name = "Subscribe")]
        public async Task<ActionResult<bool>> Subscribe(string id, string userId)
        {
            id = id.Trim();
            userId = userId.Trim();

            if (id.Length == 0 || userId.Length == 0)
                return BadRequest();

            var userSubscription = await _feedService.Subscribe(id, userId);
            if (userSubscription == null)
                return Conflict();

            return Ok(true);
        }


        // GET: api/Feeds/{id}/unsubscribe/{userId}
        [HttpGet("{id}/unsubscribe/{userId}", Name = "Unsubscribe")]
        public async Task<ActionResult<bool>> Unsubcsribe(string id, string userId)
        {
            id = id.Trim();
            userId = userId.Trim();

            if (id.Length == 0 || userId.Length == 0)
                return BadRequest();

            var userUnsubscription = await _feedService.Unsubscribe(id, userId);
            if (userUnsubscription == null)
                return Conflict();

            return Ok(true);
        }

    }
}
