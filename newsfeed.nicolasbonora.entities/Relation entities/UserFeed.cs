using System.ComponentModel.DataAnnotations.Schema;

namespace newsfeed.nicolasbonora.entities.Relation_entities
{
    [Table(name: "UserFeeds")]
    public class UserFeed : IUserFeed
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string FeedId { get; set; }
        public Feed Feed { get; set; }

        public override string ToString()
        {
            return FeedId;
        }
    }
}
