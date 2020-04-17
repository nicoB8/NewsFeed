using newsfeed.nicolasbonora.entities.Base_entities;
using newsfeed.nicolasbonora.entities.Relation_entities;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.entities
{
    public interface IUser : IBaseEntity
    {
        string Name { get; set; }
        string Email { get; set; }
        Feed Feed { get; set; }
        IEnumerable<UserFeed> FollowingFeeds { get; set; }
    }
}
