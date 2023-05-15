namespace MotorAsinBasketRobot.WebAPI.Tasks.Jobs;
public class CustomersJob:IJob
{
    private readonly IMASqlConnectionService masqlConnectionService;
    private readonly ICustomerService _customersService;
    public CustomersJob(IMASqlConnectionService masqlConnectionService, ICustomerService customersServic)
    {
        this.masqlConnectionService = masqlConnectionService;
        _customersService = customersServic;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        IDataResult<MASqlConnection> maAdminResult = await masqlConnectionService.CustomerCodeAsync("MODU", EnmConnetion.AdminDb);
        IDataResult<MASqlConnection> maCustomerServerResult = await masqlConnectionService.CustomerCodeAsync("MusteriDb", EnmConnetion.CustomerServerDb);
        IDataResult<MASqlConnection> maCustomerMotorasinResult = await masqlConnectionService.CustomerCodeAsync("MusteriMotorasinDB", EnmConnetion.CustomerMotorasinDb);
        IDataResult<IList<Customer>> documentList;
        if (maCustomerServerResult.Success && maAdminResult.Success && maCustomerMotorasinResult.Success)
        {
            await masqlConnectionService.UpdateConnections(maCustomerServerResult.Data);
            try
            {
                documentList = await _customersService.GetList(new CustomerListPramertDto { IsActive = true });
                await masqlConnectionService.UpdateConnections(maCustomerMotorasinResult.Data);
                foreach (var document in documentList.Data)
                {
                    document.Id = 0;
                    await _customersService.Create(document);
                }
            }
            catch (Exception)
            {
                documentList = new DataResult<IList<Customer>>(new List<Customer>(), false, "Hata oluştu"); // Hata durumunda boş bir liste oluşturuluyor
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
