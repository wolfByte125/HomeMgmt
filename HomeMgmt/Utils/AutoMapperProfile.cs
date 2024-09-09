using AutoMapper;
using HomeMgmt.Contexts;

namespace HomeMgmt.Utils
{
    public class AutoMapperProfile : Profile
    {
        private readonly IMapper _mapper;

        public AutoMapperProfile(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
        }

        public AutoMapperProfile()
        {
            // MAPPER PROFILES
        }
    }
}
