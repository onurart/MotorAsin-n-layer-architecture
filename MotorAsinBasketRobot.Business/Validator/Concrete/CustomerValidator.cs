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
    public class CustomerValidator : ICustomerValidator
    {
        private ICustomerDal _Customer;
        ISpeCodeDal _SpeCode;

        public CustomerValidator(ICustomerDal customer, ISpeCodeDal speCode)
        {
            _Customer = customer;
            _SpeCode = speCode;
        }

        public async Task CheckCreateAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task CheckDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CheckUpdateAsync(int id, string code, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
