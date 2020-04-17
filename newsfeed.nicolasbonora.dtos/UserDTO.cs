using newsfeed.nicolasbonora.dtos.Base_dtos;
using System.Collections.Generic;

namespace newsfeed.nicolasbonora.dtos
{
    public class UserDTO : BaseDTO, IUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> FollowingFeeds { get; set; }
    }
}
