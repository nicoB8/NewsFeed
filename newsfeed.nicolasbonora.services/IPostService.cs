using newsfeed.nicolasbonora.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace newsfeed.nicolasbonora.services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> Get(); 
        Task<IEnumerable<Post>> GetByUserId(string userId);
        Task<Post> Post(Post post);
    }
}
