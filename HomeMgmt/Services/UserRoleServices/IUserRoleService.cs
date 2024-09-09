using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.UserDTOs.UserRoleDTOs;
using HomeMgmt.Models.UserModels;

namespace HomeMgmt.Services.UserRoleServices
{
    public interface IUserRoleService
    {
        Task<UserRole> CreateUserRole(CreateUserRoleDTO userRoleDTO);
        Task<UserRole> DeleteUserRole(int id);
        Task<UserRole> ReadUserRoleById(int id);
        Task<PaginatedReturnDTO> ReadUserRoles(QueryDTO queryDTO, FilterUserRoleDTO filterDTO);
        Task<UserRole> UpdateUserRole(UserRole userRoleDTO);
    }
}
