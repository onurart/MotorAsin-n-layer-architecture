using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Entities.Dtos.IncomingOrderRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class IncomingOrderRequestsManager : IIncomingOrderRequestsService
    {
        private readonly IIncomingOrderRequestsDal _orderRequestsDal;
        private readonly IIncomingOrderRequestsValidator _requestsValidator;

        public IncomingOrderRequestsManager(IIncomingOrderRequestsDal orderRequestsDal, ISpeCodeDal speCodeDal)
        {
            _orderRequestsDal = orderRequestsDal;
            _requestsValidator = new IncomingOrderRequestsValidator(_orderRequestsDal, speCodeDal);
        }

        public Task<IDataResult<IncomingOrderRequests>> Create(IncomingOrderRequests entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IncomingOrderRequests>> Delete(IncomingOrderRequests entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IncomingOrderRequests>> Get(int id)
        {
            return new SuccessDataResult<IncomingOrderRequests>(await _orderRequestsDal.GetAsync(id, b => b.Id == id), Messages.BasketStatusGet);

        }

        public async Task<IDataResult<IList<IncomingOrderRequests>>> GetList(IncomingOrderRequestsPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<IncomingOrderRequests>>
                (await _orderRequestsDal.GetListAsync(b => b.IsActive == parameter.IsActive, b => b.Id), Messages.DocumentGetAll);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<IncomingOrderRequests>>(ex.Message);
            }
        }

        public Task<IDataResult<IncomingOrderRequests>> Update(IncomingOrderRequests entity)
        {
            throw new NotImplementedException();
        }
    }
}
