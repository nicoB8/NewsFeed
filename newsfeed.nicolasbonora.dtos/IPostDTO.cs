using newsfeed.nicolasbonora.dtos.Base_dtos;

namespace newsfeed.nicolasbonora.dtos
{
    public interface IPostDTO : IBaseDTO
    {
        string FeedId { get; set; }
        FeedDTO Feed { get; set; }
        string ContentHeader { get; set; }
    }
}
