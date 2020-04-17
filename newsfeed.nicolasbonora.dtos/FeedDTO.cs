using newsfeed.nicolasbonora.dtos.Base_dtos;

namespace newsfeed.nicolasbonora.dtos
{
    public class FeedDTO : BaseDTO, IFeedDTO
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public UserDTO Owner { get; set; }
    }
}
