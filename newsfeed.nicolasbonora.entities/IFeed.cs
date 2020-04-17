using newsfeed.nicolasbonora.entities.Base_entities;
using newsfeed.nicolasbonora.entities.Relation_entities;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.entities
{
    public interface IFeed : IBaseEntity
    {
        string Name { get; set; }
        string OwnerId { get; set; }
        User Owner { get; set; }
        IEnumerable<UserFeed> Subscribers { get; set; }
        IEnumerable<Post> Posts { get; set; }
    }
}
