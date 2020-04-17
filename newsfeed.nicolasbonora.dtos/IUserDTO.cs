using newsfeed.nicolasbonora.dtos.Base_dtos;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.dtos
{
    public interface IUserDTO : IBaseDTO
    {
        string Name { get; set; }
        string Email { get; set; }
        IEnumerable<string> FollowingFeeds { get; set; }
    }
}
