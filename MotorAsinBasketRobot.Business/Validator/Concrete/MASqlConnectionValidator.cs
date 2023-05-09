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
    public class MASqlConnectionValidator : IMASqlConnectionValidator
    {
        private readonly IMASqlConnectionDal _mASqlConnectionDal;
        private readonly ISpeCodeDal _speCodeDal;

        public MASqlConnectionValidator(IMASqlConnectionDal mASqlConnectionDal, ISpeCodeDal speCodeDal)
        {
            _mASqlConnectionDal = mASqlConnectionDal;
            _speCodeDal = speCodeDal;
        }

        public Task CheckCreateAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
