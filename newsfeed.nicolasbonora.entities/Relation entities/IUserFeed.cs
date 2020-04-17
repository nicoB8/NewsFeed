using newsfeed.nicolasbonora.entities.Base_entities;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.entities.Relation_entities
{
    public interface IUserFeed
    {
        string UserId { get; set; }
        User User { get; set; }
        string FeedId { get; set; }
        Feed Feed { get; set; }
    }
}
