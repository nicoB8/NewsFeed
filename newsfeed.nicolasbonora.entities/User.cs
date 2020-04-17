using newsfeed.nicolasbonora.entities.Base_entities;
using newsfeed.nicolasbonora.entities.Relation_entities;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.entities
{
    public class User : BaseEntity, IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Feed Feed { get; set; }
        public IEnumerable<UserFeed> FollowingFeeds { get; set; }
    }
}
