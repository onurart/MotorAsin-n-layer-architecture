using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.IO.Compression;
using ClosedXML.Excel;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using Newtonsoft.Json;
using System.Text;

namespace MotorAsinBasketRobot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private readonly IMASqlConnectionService _service;
        public DocumentController(IDocumentService documentService, IMapper mapper, AppDbContext dbContext)
        {
            _documentService = documentService;
            _mapper = mapper;
            _dbContext = dbContext;
        }


        [HttpGet("DownloadAllDocumentsAsExcel")]
        public async Task<IActionResult> DownloadAllDocumentsAsExcel([FromQuery] DocumentListPramertDto dto)
        {
            IDataResult<IList<Documents>> documentsResult = await _documentService.GetList(dto);

            if (documentsResult.Success)
            {
                IList<Documents> documents = documentsResult.Data;

                if (documents.Count == 0)
                    return NotFound();
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Documents");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "DocumetType";
                worksheet.Cell(1, 3).Value = "LineType";
                worksheet.Cell(1, 4).Value = "Billed";
                worksheet.Cell(1, 5).Value = "TlToltal";
                worksheet.Cell(1, 6).Value = "ProductReferance";
                worksheet.Cell(1, 7).Value = "CustomerReferance";
                worksheet.Cell(1, 8).Value = "DocumentNo";
                worksheet.Cell(1, 9).Value = "DocumentDate";
                worksheet.Cell(1, 10).Value = "IsActive";
                for (int i = 0; i < documents.Count; i++)
                {
                    var document = documents[i];
                    worksheet.Cell(i + 2, 1).Value = document.Id;
                    worksheet.Cell(i + 2, 2).Value = document.DocumetType;
                    worksheet.Cell(i + 2, 3).Value = document.LineType;
                    worksheet.Cell(i + 2, 4).Value = document.Billed;
                    worksheet.Cell(i + 2, 5).Value = document.TlToltal;
                    worksheet.Cell(i + 2, 6).Value = document.ProductReferance;
                    worksheet.Cell(i + 2, 7).Value = document.CustomerReferance;
                    worksheet.Cell(i + 2, 8).Value = document.DocumentNo;
                    worksheet.Cell(i + 2, 9).Value = document.DocumentDate;
                    worksheet.Cell(i + 2, 10).Value = document.IsActive;
                }

                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AllDocuments.xlsx");
            }
            else
            {
                return BadRequest(documentsResult.Message);
            }
        }


        [HttpGet("DownloadAllDocumentsAsJson")]
        public async Task<IActionResult> DownloadAllDocumentsAsJson([FromQuery] DocumentListPramertDto dto)
        {
            const int batchSize = 1000; // Her adımda işlenecek belge sayısı
            int totalDocuments = await _documentService.GetTotalCount(dto); // Toplam belge sayısını alın

            if (totalDocuments == 0)
                return NotFound();

            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, leaveOpen: true))
            {
                writer.WriteLine("[");

                for (int i = 0; i < totalDocuments; i += batchSize)
                {
                    IList<Documents> documents = await _documentService.GetBatchedList(dto, i, batchSize); // Belge listesini parça parça al

                    var json = JsonConvert.SerializeObject(documents, Formatting.None);

                    writer.Write(json);

                    if (i + batchSize < totalDocuments)
                        writer.WriteLine(",");
                }

                writer.WriteLine("]");
                writer.Flush();
                stream.Position = 0;
            }

            return File(stream, "application/json", "AllDocuments.json");
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
