using AutoMapper;
using HomeMgmt.Contexts;
using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.HomeDTOs;
using HomeMgmt.Models.GeneralModels;
using HomeMgmt.Utils;
using Microsoft.EntityFrameworkCore;

namespace HomeMgmt.Services.HomeServices
{
    public class HomeService : IHomeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HomeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Home> ReadByIdAsNoTracking(string id) => await _context.Homes
            .AsNoTracking()
            .Include(x => x.Owner)
            .Include(x => x.HouseholdMembers)
            .FirstOrDefaultAsync(x => x.Id == id)
            ??
            throw new KeyNotFoundException("Home Not Found.");

        private async Task<Home> ReadById(string id) => await _context.Homes
            .Include(x => x.Owner)
            .Include(x => x.HouseholdMembers)
            .FirstOrDefaultAsync(x => x.Id == id)
            ??
            throw new KeyNotFoundException("Home Not Found.");

        public async Task<PaginatedReturnDTO> ReadAll(QueryDTO queryDTO, FilterHomeDTO filterDTO)
        {
            IQueryable<Home> query = _context.Homes
                .AsNoTracking()
                .Where(x =>
                    (filterDTO.OwnerId == null || x.OwnerId == filterDTO.OwnerId))
                .OrderByDescending(x => x.CreatedAt);

            if (queryDTO.KeyWord != null)
            {
                query = query.Where(x =>
                    x.Name.Contains(queryDTO.KeyWord) ||
                    x.Address.Contains(queryDTO.KeyWord) ||
                    x.Owner.FullName.Contains(queryDTO.KeyWord));
            }

            int totalDataCount = await query.CountAsync();
            int numberOfPages = (int)Math.Ceiling((double)totalDataCount / GENERAL.PAGE_SIZE);

            List<Home> paginatedQuery = await query
                .Include(x => x.Owner)
                .Skip(GENERAL.PAGE_SIZE * (queryDTO.PageNumber - 1))
                .Take(GENERAL.PAGE_SIZE)
                .ToListAsync();

            PaginatedReturnDTO paginatedResponse = new()
            {
                Data = paginatedQuery,
                Pages = numberOfPages,
                TotalData = totalDataCount,
            };

            return paginatedResponse;
        }

        public async Task<Home> Create(CreateHomeDTO homeDTO)
        {
            Home home = new()
            {
                Name = homeDTO.Name,
                Address = homeDTO.Address,
                OwnerId = homeDTO.HouseholdMembers
                    .Where(x => x.IsOwner)
                    .Select(x => x.MemberId)
                    .First(),
                HouseholdMembers = _context.UserAccounts
                    .Where(x => homeDTO.HouseholdMembers.Select(x => x.MemberId).Contains(x.Id))
                    .ToList()
            };

            _context.Homes.Add(home);
            await _context.SaveChangesAsync();

            return home;
        }

        public async Task<Home> Update(UpdateHomeDTO homeDTO)
        {
            // UNDER CONSTRUCTION
            throw new NotImplementedException();
        }

        public async Task<Home> Delete(string id)
        {
            Home home = await ReadById(id: id);

            // VALIDATIONS
            // - if any stock exists for this home, then invalid

            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();

            return home;
        }
    }
}
