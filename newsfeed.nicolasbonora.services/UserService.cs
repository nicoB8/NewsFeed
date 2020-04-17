using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newsfeed.nicolasbonora.entities;
using newsfeed.nicolasbonora.repository;

namespace newsfeed.nicolasbonora.services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(NewsFeedContext context) : base(context)
        {}

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.Include(u => u.FollowingFeeds).ToListAsync();
        }

        public async Task<User> Get(string id)
        {
            return await _context.Users.Include(u => u.FollowingFeeds).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> Post(User user)
        {
            if (ExistsByEmail(user.Email))
                return null;

            user.Id = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            user.Feed = new Feed(user.Id, "MainFeed");

            var newUser = await _context.Users.AddAsync(user);
            await SaveChangesAsync();
            return newUser.Entity;
        }

        public bool ExistsByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            return user != null ? true : false;
        }

        public bool ExistsById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user != null ? true : false;
        }
    }
}
