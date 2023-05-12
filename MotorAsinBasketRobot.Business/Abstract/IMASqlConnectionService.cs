using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.MASqlConnection;
using MotorAsinBasketRobot.Shared.Enums;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IMASqlConnectionService : IBaseService<MASqlConnection>
    {
        Task<IDataResult<MASqlConnection>> CustomerCodeAsync(string code, EnmConnetion customerServer);
        Task<IDataResult<MASqlConnection>> GetCustomerAsync();
        Task<IDataResult<IList<MASqlConnection>>> GetList(MASqlConnectionListPramertDto parameter);
        Task UpdateConnections(MASqlConnection maSqlConnection);
    }
}
