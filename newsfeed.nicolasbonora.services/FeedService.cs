using System.Threading.Tasks;
using newsfeed.nicolasbonora.entities.Relation_entities;
using newsfeed.nicolasbonora.repository;

namespace newsfeed.nicolasbonora.services
{
    public class FeedService : BaseService, IFeedService
    {
        public FeedService(NewsFeedContext context) : base(context)
        {}

        public async Task<UserFeed> Subscribe(string id, string userId)
        {
            var userFeedRelation = new UserFeed()
            {
                FeedId = id,
                UserId = userId
            };

            var relationCreated = await _context.UserFeeds.AddAsync(userFeedRelation);
            await SaveChangesAsync();
            return relationCreated.Entity;
        }
    }
}
