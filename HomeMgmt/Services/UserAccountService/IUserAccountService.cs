using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.Models.UserModels;

namespace HomeMgmt.Services.UserAccountService
{
    public interface IUserAccountService
    {
        Task<UserAccount> ActivateUserAccount(string id);
        Task<UserAccount> BanUserAccount(BanUserAccountDTO banDTO);
        bool CheckUsernameTaken(string username);
        Task<UserAccount> DeactivateUserAccount(string id);
        Task<UserAccount> DeleteUserAccount(string id);
        Task<UserAccount> ReadUserAccountById(string id);
        Task<PaginatedReturnDTO> ReadUserAccounts(QueryDTO? queryDTO, FilterUserAccountDTO? filterDTO);
        Task<UserAccount> UpdateUserAccount(UpdateUserAccountDTO updateDTO);
    }
}
