using System;

namespace newsfeed.nicolasbonora.dtos.Base_dtos
{
    public class BaseDTO : IBaseDTO
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
