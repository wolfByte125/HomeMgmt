using HomeMgmt.DTOs.GeneralDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmt.Utils
{
    public static class ControllerBaseExtension
    {
        public static ActionResult ParseException(this ControllerBase controller, Exception exception)
        {
            try
            {
                throw exception;
            }
            catch (KeyNotFoundException ex)
            {
                return controller.NotFound(ReturnMessage.Parse(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return controller.BadRequest(ReturnMessage.Parse(ex.Message));
            }
            catch (UnauthorizedAccessException)
            {
                return new ObjectResult("Forbidden")
                {
                    StatusCode = 403,
                    Value = ReturnMessage.Parse("Access Denied.")
                };
            }
        }
    }
}
