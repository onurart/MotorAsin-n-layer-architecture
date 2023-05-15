using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Entities.Dtos.ProductsCampaigns;

namespace MotorAsinBasketRobot.WebAPI.Tasks.Jobs
{
    public class ProductsCampaignsJobs:IJob
    {
        private readonly IMASqlConnectionService masqlConnectionService;
        private readonly IProductsCampaignsService _productsCampaignsService;

        public ProductsCampaignsJobs(IMASqlConnectionService masqlConnectionService, IProductsCampaignsService productsCampaignsService)
        {
            this.masqlConnectionService = masqlConnectionService;
            _productsCampaignsService = productsCampaignsService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            IDataResult<MASqlConnection> maAdminResult = await masqlConnectionService.CustomerCodeAsync("MODU", EnmConnetion.AdminDb);
            IDataResult<MASqlConnection> maCustomerServerResult = await masqlConnectionService.CustomerCodeAsync("MusteriDb", EnmConnetion.CustomerServerDb);
            IDataResult<MASqlConnection> maCustomerMotorasinResult = await masqlConnectionService.CustomerCodeAsync("MusteriMotorasinDB", EnmConnetion.CustomerMotorasinDb);
            IDataResult<IList<ProductsCampaigns>> documentList;
            if (maCustomerServerResult.Success && maAdminResult.Success && maCustomerMotorasinResult.Success)
            {
                await masqlConnectionService.UpdateConnections(maCustomerServerResult.Data);
                try
                {
                    documentList = await _productsCampaignsService.GetList(new ProductsCampaignsListPramertDto { IsActive = true });
                    await masqlConnectionService.UpdateConnections(maCustomerMotorasinResult.Data);
                    foreach (var document in documentList.Data)
                    {
                        document.Id = 0;
                        await _productsCampaignsService.Create(document);
                    }
                }
                catch (Exception)
                {
                    documentList = new DataResult<IList<ProductsCampaigns>>(new List<ProductsCampaigns>(), false, "Hata oluştu"); // Hata durumunda boş bir liste oluşturuluyor
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
