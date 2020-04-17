using newsfeed.nicolasbonora.dtos.Base_dtos;

namespace newsfeed.nicolasbonora.dtos
{
    public class PostDTO : BaseDTO, IPostDTO
    {
        public string FeedId { get; set; }
        public FeedDTO Feed { get; set; }
        public string ContentHeader { get; set; }
    }
}
