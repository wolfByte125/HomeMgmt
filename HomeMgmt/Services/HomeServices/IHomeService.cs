using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.HomeDTOs;
using HomeMgmt.Models.GeneralModels;

namespace HomeMgmt.Services.HomeServices
{
    public interface IHomeService
    {
        Task<Home> Create(CreateHomeDTO homeDTO);
        Task<Home> Delete(string id);
        Task<PaginatedReturnDTO> ReadAll(QueryDTO queryDTO, FilterHomeDTO filterDTO);
        Task<Home> ReadByIdAsNoTracking(string id);
        Task<Home> Update(UpdateHomeDTO homeDTO);
    }
}
