using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Entities.Dtos.Offer;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] OfferListPramertDto dto)
        {
            IDataResult<IList<Offer>> result = await _offerService.GetList(dto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<Offer>, IList<Offer>>(result.Data));
            }
            return BadRequest(result.Message);
        }

        //[HttpGet("GetList")]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _offerService.TestGetListAsync();
        //    if (list.Success)
        //    {
        //        return Ok(list.Data);
        //    }
        //    return BadRequest(list.Message);
        //}
    }
}
