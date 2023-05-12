using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Shared.Enums;
using Quartz;
namespace MotorAsinBasketRobot.WebAPI.Tasks.Jobs
{
    public class DocumentsJob : IJob
    {
        private readonly IMASqlConnectionService masqlConnectionService;
        private readonly IDocumentService _documentService;
        public DocumentsJob(IMASqlConnectionService masqlConnectionService, IDocumentService documentService)
        {
            this.masqlConnectionService = masqlConnectionService;
            _documentService = documentService;
        }
        public async Task Execute(IJobExecutionContext context)
        {

            IDataResult<MASqlConnection> maAdminResult = await masqlConnectionService.CustomerCodeAsync("MODU", EnmConnetion.AdminDb);

            IDataResult<MASqlConnection> maCustomerServerResult = await masqlConnectionService.CustomerCodeAsync("MusteriDb", EnmConnetion.CustomerServerDb);

            IDataResult<MASqlConnection> maCustomerMotorasinResult = await masqlConnectionService.CustomerCodeAsync("MusteriMotorasinDB", EnmConnetion.CustomerMotorasinDb);
            
            //IDataResult<MASqlConnection> maAdminResult = await masqlConnectionService.CustomerCodeAsync("MODU", EnmConnetion.AdminDb);

            //IDataResult<MASqlConnection> maCustomerServerResult = await masqlConnectionService.CustomerCodeAsync("MusteriDb", EnmConnetion.CustomerServerDb);

            //IDataResult<MASqlConnection> maCustomerMotorasinResult = await masqlConnectionService.CustomerCodeAsync("MusteriMotorasinDB", EnmConnetion.CustomerMotorasinDb);


            IDataResult<IList<Documents>> documentList;
            if (maCustomerServerResult.Success && maAdminResult.Success && maCustomerMotorasinResult.Success)
            //if (maCustomerServerResult.Success)
            {
                await masqlConnectionService.UpdateConnections(maCustomerServerResult.Data);
                try
                {
                    documentList = await _documentService.GetList(new DocumentListPramertDto { IsActive = true });


                    await masqlConnectionService.UpdateConnections(maCustomerMotorasinResult.Data);
                    
                    foreach (var document in documentList.Data)
                    {
                        document.Id = 0;
                        await _documentService.Create(document);
                    }
                }
                catch (Exception)
                {
                    documentList = new DataResult<IList<Documents>>(new List<Documents>(), false, "Hata oluştu"); // Hata durumunda boş bir liste oluşturuluyor
                }
                finally
                {
                    await masqlConnectionService.UpdateConnections(maAdminResult.Data);
                }

            }
            else
            {
                // Müşteri bulunamadı durumunda yapılacak işlemler
            }
            await Task.CompletedTask;
        }



    }
}
