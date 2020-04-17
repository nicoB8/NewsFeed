using newsfeed.nicolasbonora.entities.Base_entities;

namespace newsfeed.nicolasbonora.entities
{
    public class Post : BaseEntity, IPost
    {
        public string FeedId { get; set; }
        public Feed Feed { get; set; }
        public string ContentHeader { get; set; }
    }
}
