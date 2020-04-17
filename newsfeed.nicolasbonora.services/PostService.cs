using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newsfeed.nicolasbonora.entities;
using newsfeed.nicolasbonora.repository;

namespace newsfeed.nicolasbonora.services
{
    public class PostService : BaseService, IPostService
    {
        public PostService(NewsFeedContext context) : base(context)
        {}

        public async Task<IEnumerable<Post>> Get()
        {
            return await _context.Posts.OrderByDescending(p => p.CreatedDate).Take(50)
                .Include(p => p.Feed).ThenInclude(f => f.Owner).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetByUserId(string userId)
        {
            var followingFeeds = _context.UserFeeds.Where(uf => uf.UserId == userId).Select(uf => uf.FeedId);
            return await _context.Posts.OrderByDescending(p => p.CreatedDate).Take(50)
                .Include(p => p.Feed).ThenInclude(f => f.Owner).Where(p => followingFeeds.Contains(p.FeedId)).ToListAsync();
        }

        public async Task<Post> Post(Post post)
        {
            post.CreatedDate = DateTime.Now;
            post.Id = Guid.NewGuid().ToString();

            var newPost = await _context.Posts.AddAsync(post);
            await SaveChangesAsync();

            newPost.Entity.Feed = await _context.Feeds.Include(f => f.Owner).FirstOrDefaultAsync(f => f.Id == post.FeedId);
            return newPost.Entity;
        }
    }
}
