using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.IncomingOrderRequests;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingOrderRequestController : ControllerBase
    {
        private readonly IIncomingOrderRequestsService _incomingOrderRequestsService;
        private readonly IMapper _mapper;

        public IncomingOrderRequestController(IIncomingOrderRequestsService incomingOrderRequestsService, IMapper mapper)
        {
            _incomingOrderRequestsService = incomingOrderRequestsService;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] IncomingOrderRequestsPramertDto dto)
        {
            IDataResult<IList<IncomingOrderRequests>> result = await _incomingOrderRequestsService.GetList(dto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<IncomingOrderRequests>, IList<IncomingOrderRequests>>(result.Data));
            }
            return BadRequest(result.Message);
        }
    }
}
