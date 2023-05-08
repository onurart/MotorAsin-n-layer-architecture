using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.SpeCodeListParameterDto;
using MotorAsinBasketRobot.Entities.Dtos.SpeCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface ISpeCodeService : IBaseService<SpeCode>
    {
        Task<IDataResult<PagedResult<SpeCode>>> GetPagedList(SpeCodeListParameterDto parameter);
        Task<IDataResult<IList<SpeCode>>> GetList(SpeCodeListParameterDto parameter);
        Task<IDataResult<string>> GetCode(SpeCodeParameterDto parameter);
    }
}
