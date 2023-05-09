using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Entities.Dtos.MASqlConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IMASqlConnectionService : IBaseService<MASqlConnection>
    {
        Task<IDataResult<IList<MASqlConnection>>> GetList(MASqlConnectionListPramertDto parameter);
    }
}
