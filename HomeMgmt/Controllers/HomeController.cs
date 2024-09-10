using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.HomeDTOs;
using HomeMgmt.Helpers.ValidatorServices;
using HomeMgmt.Models.GeneralModels;
using HomeMgmt.Services.HomeServices;
using HomeMgmt.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = AUTHORIZATION.EXCLUDE_INACTIVE)]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly IValidatorService _validatorService;

        public HomeController(IHomeService homeService, IValidatorService validatorService)
        {
            _homeService = homeService;
            _validatorService = validatorService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadByIdAsNoTracking(string id)
        {
            try
            {
                return Ok(await _homeService.ReadByIdAsNoTracking(id: id));
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ReadAll([FromQuery] QueryDTO queryDTO, [FromQuery] FilterHomeDTO filterDTO)
        {
            try
            {
                return Ok(await _homeService.ReadAll(queryDTO: queryDTO, filterDTO: filterDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateHomeDTO homeDTO)
        {
            try
            {
                _validatorService.Validate(new Home()
                {
                    Name = homeDTO.Name,
                    OwnerId = homeDTO.HouseholdMembers.Where(x => x.IsOwner).Select(x => x.MemberId).FirstOrDefault()
                });

                return Ok(await _homeService.Create(homeDTO: homeDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult> Update(UpdateHomeDTO homeDTO)
        {
            try
            {
                _validatorService.Validate(new Home()
                {
                    Name = homeDTO.Name,
                    OwnerId = homeDTO.HouseholdMembers.Where(x => x.IsOwner).Select(x => x.MemberId).FirstOrDefault()
                });

                return Ok(await _homeService.Update(homeDTO: homeDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _homeService.Delete(id: id));
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }
    }
}
