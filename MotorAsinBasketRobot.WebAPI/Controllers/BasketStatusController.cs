using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketStatusController : ControllerBase
    {
        private readonly IBasketStatusService _basketStatusService;
        private readonly IMapper _mapper;
        public BasketStatusController(IBasketStatusService basketStatusService, IMapper mapper)
        {
            _basketStatusService = basketStatusService;
            _mapper = mapper;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            IDataResult<BasketStatus> result = await _basketStatusService.Get(id);
            if (result.Success)
            {
                return Ok(_mapper.Map<BasketStatus, SelectBaskeStatustDto>(result.Data));
            }
            return BadRequest(result.Message);
        }
        //[HttpGet("GetCode")]
        //public async Task<IActionResult> GetCode([FromQuery] BasketStatusCodeParameterDto code)
        //{
        //    IDataResult<string> result = await _basketStatusService.GetCode(code);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}
        [HttpGet("GetList")]

        public async Task<IActionResult> GetList([FromQuery] BasketStatusListParameterDto parameterDto)
        {
            IDataResult<IList<BasketStatus>> result = await _basketStatusService.GetList(parameterDto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<BasketStatus>, IList<ListBasketStatusDto>>(result.Data));
            }
            return BadRequest(result.Message);
        }



        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateBasketStatus updateDto)
        {
            BasketStatus category = _mapper.Map<UpdateBasketStatus, BasketStatus>(updateDto);
            category.Id = id;
            IDataResult<BasketStatus> result = await _basketStatusService.Update(category);
            if (result.Success)
            {
                return Ok(_mapper.Map<BasketStatus, SelectBaskeStatustDto>(result.Data));
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] SelectBaskeStatustDto deletedDto)
        {
            IDataResult<BasketStatus> result = await _basketStatusService.Delete(_mapper.Map<SelectBaskeStatustDto, BasketStatus>(deletedDto));
            if (result.Success)
            {
                return Ok(_mapper.Map<BasketStatus, SelectBaskeStatustDto>(result.Data));
            }
            return BadRequest(result.Message);
        }

    }
}
