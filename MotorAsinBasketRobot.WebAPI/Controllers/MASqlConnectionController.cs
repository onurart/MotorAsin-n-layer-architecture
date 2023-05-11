using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.MASqlConnection;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MASqlConnectionController : ControllerBase
    {
        private readonly IMASqlConnectionService _connectionService;
       private readonly IMapper _mapper;

        public MASqlConnectionController(IMASqlConnectionService connectionService, IMapper mapper)
        {
            _connectionService = connectionService;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] MASqlConnectionListPramertDto dto)
        {
            IDataResult<IList<MASqlConnection>> result = await _connectionService.GetList(dto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<MASqlConnection>, IList<MASqlConnection>>(result.Data));
            }
            return BadRequest(result.Message);
        }
    }
}
