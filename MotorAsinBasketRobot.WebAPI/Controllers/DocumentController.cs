using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] DocumentListPramertDto dto)
        {
            IDataResult<IList<Documents>> result = await _documentService.GetList(dto);
            if (result.Success)
            {
                return Ok(_mapper.Map<IList<Documents>, IList<Documents>>(result.Data));
            }
            return BadRequest(result.Message);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            IDataResult<Documents> result = await _documentService.Get(id);
            if (result.Success)
            {
                return Ok(_mapper.Map<Documents, Documents>(result.Data));
            }
            return BadRequest(result.Message);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateDocumentDto updateDto)
        {
            Documents documents = _mapper.Map<UpdateDocumentDto, Documents>(updateDto);
            documents.Id = id;
            IDataResult<Documents> result = await _documentService.Update(documents);
            if (result.Success)
            {
                return Ok(_mapper.Map<Documents, SelectDocumentDto>(result.Data));
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] SelectDocumentDto deletedDto)
        {
            IDataResult<Documents> result = await _documentService.Delete(_mapper.Map<SelectDocumentDto, Documents>(deletedDto));
            if (result.Success)
            {
                return Ok(_mapper.Map<Documents, SelectDocumentDto>(result.Data));
            }
            return BadRequest(result.Message);
        }
    }
}
