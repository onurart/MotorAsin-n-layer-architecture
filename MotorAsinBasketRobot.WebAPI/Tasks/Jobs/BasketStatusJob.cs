namespace MotorAsinBasketRobot.WebAPI.Tasks.Jobs;
public class BasketStatusJob : IJob
{
    private readonly IMASqlConnectionService masqlConnectionService;
    private readonly IBasketStatusService _basketStatusService;
    public BasketStatusJob(IMASqlConnectionService masqlConnectionService, IBasketStatusService basketStatusService)
    {
        this.masqlConnectionService = masqlConnectionService;
        _basketStatusService = basketStatusService;
    }
    public async Task Execute(IJobExecutionContext context)
    {

        IDataResult<MASqlConnection> maAdminResult = await masqlConnectionService.CustomerCodeAsync("MODU", EnmConnetion.AdminDb);
        IDataResult<MASqlConnection> maCustomerServerResult = await masqlConnectionService.CustomerCodeAsync("MusteriDb", EnmConnetion.CustomerServerDb);
        IDataResult<MASqlConnection> maCustomerMotorasinResult = await masqlConnectionService.CustomerCodeAsync("MusteriMotorasinDB", EnmConnetion.CustomerMotorasinDb);
        IDataResult<IList<BasketStatus>> documentList;
        if (maCustomerServerResult.Success && maAdminResult.Success && maCustomerMotorasinResult.Success)
        {
            await masqlConnectionService.UpdateConnections(maCustomerServerResult.Data);
            try
            {
                documentList = await _basketStatusService.GetList(new BasketStatusListParameterDto { IsActive = true });
                await masqlConnectionService.UpdateConnections(maCustomerMotorasinResult.Data);
                foreach (var document in documentList.Data)
                {
                    document.Id = 0;
                    await _basketStatusService.Create(document);
                }
            }
            catch (Exception)
            {
                documentList = new DataResult<IList<BasketStatus>>(new List<BasketStatus>(), false, "Hata oluştu"); // Hata durumunda boş bir liste oluşturuluyor
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
