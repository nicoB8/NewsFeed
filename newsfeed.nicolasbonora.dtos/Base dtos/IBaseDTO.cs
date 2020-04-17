using System;

namespace newsfeed.nicolasbonora.dtos.Base_dtos
{
    public interface IBaseDTO
    {
        string Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
