using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IDocumentService : IBaseService<Documents>
    {
        Task<IDataResult<IList<Documents>>> GetList(DocumentListPramertDto parameter);
        Task<IDataResult<string>> GetCode(DocumentCodeParameterDto parameter);
    }
}
