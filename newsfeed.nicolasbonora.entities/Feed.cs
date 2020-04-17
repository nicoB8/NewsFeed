using newsfeed.nicolasbonora.entities.Base_entities;
using newsfeed.nicolasbonora.entities.Relation_entities;
using System;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.entities
{
    public class Feed : BaseEntity, IFeed
    {
        public Feed(string ownerId, string name)
        {
            OwnerId = ownerId;
            Id = ownerId;
            Name = name;
            CreatedDate = DateTime.Now;
            Subscribers = new List<UserFeed>()
            {
                new UserFeed()
                {
                    FeedId = ownerId,
                    UserId = ownerId
                }
            };
        }

        public string Name { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public IEnumerable<UserFeed> Subscribers { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
