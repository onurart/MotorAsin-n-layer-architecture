using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Customer;
using MotorAsinBasketRobot.Entities.Dtos.Product;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] CustomerListPramertDto dto)
        {
            IDataResult<IList<Customer>> result = await _customerService.GetList(dto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<Customer>, IList<Customer>>(result.Data));
            }
            return BadRequest(result.Message);
        }
    }
}
