using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.Models.UserModels;
using HomeMgmt.Services.UserAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtTest.Controllers
{

    public class UserAccountTestController
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountTestController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        public async Task<UserAccount> ReadUserAccountById(string id)
        {
            try
            {
                return await _userAccountService.ReadUserAccountById(id: id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaginatedReturnDTO> ReadUserAccounts(QueryDTO queryDTO, FilterUserAccountDTO filterDTO)
        {
            try
            {
                return await _userAccountService.ReadUserAccounts(queryDTO: queryDTO, filterDTO: filterDTO);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
