using newsfeed.nicolasbonora.entities.Relation_entities;
using System.Threading.Tasks;

namespace newsfeed.nicolasbonora.services
{
    public interface IFeedService
    {
        Task<UserFeed> Subscribe(string id, string userId);
    }
}
