using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppLightBreaksSolution.DTOS;
using FluentValidation;
using AppLightBreaksSolution.Services;

namespace AppLightBreaksSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IValidator<ScheduleDTO> _queryValidator;
        private ISchedulerService _schedulerService;

        public ScheduleController(IValidator<ScheduleDTO> queryValidator,ISchedulerService schedulerService)
        {
            _queryValidator = queryValidator;
            _schedulerService = schedulerService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] ScheduleDTO schedule)
        {
            var validationResult = await _queryValidator.ValidateAsync(schedule);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var results =  await _schedulerService.Get(schedule.DocumentIdentification,schedule.DocumentType);
            return Ok(results);
        }
    }
}
