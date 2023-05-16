using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCampaignsController : ControllerBase
    {
        private readonly IProductsCampaignsService _productsCampaignsService;
        private readonly IMapper _mapper;

        public ProductsCampaignsController(IProductsCampaignsService productsCampaignsService, IMapper mapper)
        {
            _productsCampaignsService = productsCampaignsService;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] ProductsCampaignsListPramertDto dto)
        {
            IDataResult<IList<ProductsCampaigns>> result = await _productsCampaignsService.GetList(dto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<ProductsCampaigns>, IList<ProductsCampaigns>>(result.Data));
            }
            return BadRequest(result.Message);
        }
    }
}
