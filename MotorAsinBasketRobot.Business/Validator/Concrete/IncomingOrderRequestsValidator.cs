using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Validator.Concrete
{
    public class IncomingOrderRequestsValidator : IIncomingOrderRequestsValidator
    {
        private readonly IIncomingOrderRequestsDal _orderRequestsDal;
        private readonly ISpeCodeDal _peCodeDal;

        public IncomingOrderRequestsValidator(IIncomingOrderRequestsDal orderRequestsDal, ISpeCodeDal peCodeDal)
        {
            _orderRequestsDal = orderRequestsDal;
            _peCodeDal = peCodeDal;
        }

        public Task CheckCreateAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task CheckDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CheckUpdateAsync(int id, string code, Documents entity)
        {
            throw new NotImplementedException();
        }
    }
}
