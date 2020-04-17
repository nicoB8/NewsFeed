using AutoMapper;
using newsfeed.nicolasbonora.dtos;
using newsfeed.nicolasbonora.dtos.Base_dtos;
using newsfeed.nicolasbonora.entities;
using newsfeed.nicolasbonora.entities.Base_entities;

namespace newsfeed.nicolasbonora.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateDtosToEntitiesMappings();
            CreateEntitiesToDtosMappings();
        }

        //From DTO (Objects that came from external fonts) to Entities (Database objects)
        private void CreateDtosToEntitiesMappings()
        {
            CreateMap<BaseDTO, BaseEntity>();
            CreateMap<UserDTO, User>();
            CreateMap<FeedDTO, Feed>();
            CreateMap<PostDTO, Post>();
        }

        //From Entities (Database objects) to DTO (Objects that came from external fonts)
        private void CreateEntitiesToDtosMappings()
        {
            CreateMap<BaseEntity, BaseDTO>();
            CreateMap<User, UserDTO>()
                .ForMember(m => m.FollowingFeeds, map => map.ToString());
            CreateMap<Feed, FeedDTO>();
            CreateMap<Post, PostDTO>();
        }
    }
}
