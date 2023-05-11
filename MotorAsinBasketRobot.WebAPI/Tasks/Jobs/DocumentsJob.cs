using Autofac.Core;
using Microsoft.AspNetCore.Mvc;
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

            IDataResult<MASqlConnection> maCustomerServerResult = await masqlConnectionService.CustomerCodeAsync("MusteriDB", EnmConnetion.CustomerServerDb);

            IDataResult<MASqlConnection> maCustomerMotorasinResult = await masqlConnectionService.CustomerCodeAsync("MusteriMotorasinDB", EnmConnetion.CustomerMotorasinDb);
            IDataResult<IList<Documents>> documentList;
            if (maCustomerServerResult.Success && maAdminResult.Success && maCustomerMotorasinResult.Success)
            //if (maCustomerServerResult.Success)
            {
                await masqlConnectionService.UpdateConnections($"Data Source={maCustomerServerResult.Data.ServerName};Initial Catalog={maCustomerServerResult.Data.DbName};User ID={maCustomerServerResult.Data.UserName};Password={maCustomerServerResult.Data.Password};Connect Timeout={maCustomerServerResult.Data.Timeout};Encrypt={maCustomerServerResult.Data.Encrypt};Trust Server Certificate={maCustomerServerResult.Data.Certificate};Application Intent={maCustomerServerResult.Data.ApplicationIntent};Multi Subnet Failover={maCustomerServerResult.Data.Failover}");
                try
                {
                    documentList = await _documentService.GetList(new DocumentListPramertDto { IsActive = true });
                    await masqlConnectionService.UpdateConnections($"Data Source={maCustomerMotorasinResult.Data.ServerName};Initial Catalog={maCustomerMotorasinResult.Data.DbName};Connect Timeout={maCustomerMotorasinResult.Data.Timeout};Encrypt={maCustomerMotorasinResult.Data.Encrypt};Trust Server Certificate={maCustomerMotorasinResult.Data.Certificate};Application Intent={maCustomerMotorasinResult.Data.ApplicationIntent};Multi Subnet Failover={maCustomerMotorasinResult.Data.Failover}");
                    foreach (var document in documentList.Data)
                    {
                        await _documentService.Create(document);
                    }
                }
                catch (Exception)
                {
                    documentList = new DataResult<IList<Documents>>(new List<Documents>(), false, "Hata oluştu"); // Hata durumunda boş bir liste oluşturuluyor
                }
                finally
                {
                    await masqlConnectionService.UpdateConnections($"Data Source={maAdminResult.Data.ServerName};Initial Catalog={maAdminResult.Data.DbName};User ID={maAdminResult.Data.UserName};Password={maAdminResult.Data.Password};Connect Timeout={maAdminResult.Data.Timeout};Encrypt={maAdminResult.Data.Encrypt};Trust Server Certificate={maAdminResult.Data.Certificate};Application Intent={maAdminResult.Data.ApplicationIntent};Multi Subnet Failover={maAdminResult.Data.Failover}");
                }

                if (documentList.Success)
                {
                    IEnumerable<Documents> documents = documentList.Data;
                    if (documents != null)
                    {
                        foreach (var document in documents)
                        {
                            await _documentService.Create(document);
                        }
                    }
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
