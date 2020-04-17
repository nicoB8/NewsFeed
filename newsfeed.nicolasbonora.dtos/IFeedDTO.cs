using newsfeed.nicolasbonora.dtos.Base_dtos;

namespace newsfeed.nicolasbonora.dtos
{
    public interface IFeedDTO : IBaseDTO
    {
        string Name { get; set; }
        string OwnerId { get; set; }
        UserDTO Owner { get; set; }
    }
}
