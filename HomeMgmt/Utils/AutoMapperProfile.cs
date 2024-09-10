using AutoMapper;
using HomeMgmt.Contexts;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.DTOs.UserDTOs.UserRoleDTOs;
using HomeMgmt.Models.UserModels;

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
            #region USER RELATED

            // USER ACCOUNT
            CreateMap<RegisterUserAccountDTO, UserAccount>();
            CreateMap<UpdateUserAccountDTO, UserAccount>();

            // USER ROLE
            CreateMap<CreateUserRoleDTO, UserRole>();
            CreateMap<UserRole, UserRole>();
            CreateMap<Permissions, Permissions>();

            // BAN USER ACCOUNT
            CreateMap<BanUserAccountDTO, BannedAccount>();

            #endregion
        }
    }
}
