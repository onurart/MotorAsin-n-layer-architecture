using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Product;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this.mapper = mapper;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            IDataResult<Product> result = await _productService.Get(id);
            if (result.Success)
            {
                return Ok(mapper.Map<Product, SelectProductDto>(result.Data));
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetCode")]
        public async Task<IActionResult> GetCode([FromQuery] ProductCodeParameterDto dto)
        {
            IDataResult<string> result = await _productService.GetCode(dto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] ProductListPramertDto dto)
        {
            IDataResult<IList<Product>> result = await _productService.GetList(dto);
            if (result.Success)
            {
                return Ok(mapper.Map<IList<Product>, IList<Product>>(result.Data));
            }
            return BadRequest(result.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateProductDto updateDto)
        {
            Product product = mapper.Map<UpdateProductDto, Product>(updateDto);
            product.Id = id;
            IDataResult<Product> result = await _productService.Update(product);
            if (result.Success)
            {
                return Ok(mapper.Map<Product, SelectProductDto>(result.Data));
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] SelectProductDto deletedDto)
        {
            IDataResult<Product> result = await _productService.Delete(mapper.Map<SelectProductDto, Product>(deletedDto));
            if (result.Success)
            {
                return Ok(mapper.Map<Product, SelectProductDto>(result.Data));
            }
            return BadRequest(result.Message);
        }

    }
}
