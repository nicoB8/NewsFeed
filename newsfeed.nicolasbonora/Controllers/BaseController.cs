using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace newsfeed.nicolasbonora.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
