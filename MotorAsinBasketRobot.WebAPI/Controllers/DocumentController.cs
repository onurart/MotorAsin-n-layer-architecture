using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Shared.Enums;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private readonly IMASqlConnectionService _service;
        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }


        //[HttpGet("ClientGetCustomer")]
        //public async Task<IActionResult> ClientGetCustomer(string customerCode)
        //{
        //    IDataResult<MASqlConnection> adminResult = await _service.CustomerCodeAsync("MODU", EnmConnetion.AdminDb);

        //    IDataResult<MASqlConnection> customerServerDb = await _service.CustomerCodeAsync(customerCode, EnmConnetion.CustomerServerDb);

        //    IDataResult<MASqlConnection> customerMotorasinDb = await _service.CustomerCodeAsync(customerCode, EnmConnetion.CustomerMotorasinDb);

        //    IDataResult<IEnumerable<Documents>> documents;
        //    if (customerServerDb.Success && adminResult.Success && customerMotorasinDb.Success)
        //    {
        //        await _service.UpdateConnections($"Data Source={customerServerDb.Data.ServerName};Initial Catalog={customerServerDb.Data.DbName};User ID={customerServerDb.Data.UserName};Password={customerServerDb.Data.Password};Connect Timeout={customerServerDb.Data.Timeout};Encrypt={customerServerDb.Data.Encrypt};Trust Server Certificate={customerServerDb.Data.Certificate};Application Intent={customerServerDb.Data.ApplicationIntent};Multi Subnet Failover={customerServerDb.Data.Failover}");
        //        try
        //        {
        //            documents = await _documentService.GetList(new DocumentListPramertDto { IsActive=true});
        //        }
        //        catch (Exception)
        //        {
        //           //documents =  new List<Documents>();
        //        }
        //        finally
        //        {
        //            await _service.UpdateConnections($"Data Source={adminResult.Data.ServerName};Initial Catalog={adminResult.Data.DbName};User ID={adminResult.Data.UserName};Password={adminResult.Data.Password};Connect Timeout={adminResult.Data.Timeout};Encrypt={adminResult.Data.Encrypt};Trust Server Certificate={adminResult.Data.Certificate};Application Intent={adminResult.Data.ApplicationIntent};Multi Subnet Failover={adminResult.Data.Failover}");
        //        }

        //        //foreach (Documents document in documents)
        //        //{
        //        //    await _documentService.Create(document);
        //        //}

        //        return Ok(customerServerDb.Data);
        //    }
        //    else
        //    {
        //        return BadRequest("Müşteri bulunamadı!");
        //    }
        //}




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
