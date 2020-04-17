using newsfeed.nicolasbonora.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace newsfeed.nicolasbonora.services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(string id);
        Task<User> Post(User user);
        bool ExistsByEmail(string email);
        bool ExistsById(string id);
    }
}
