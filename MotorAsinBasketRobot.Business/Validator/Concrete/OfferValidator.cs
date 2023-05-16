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
    internal class OfferValidator : IOfferValidator
    {
        private readonly IOfferDal _offerDal;
        private readonly ISpeCodeDal _speCodeDal;
        public OfferValidator(IOfferDal offerDal, ISpeCodeDal speCodeDa)
        {
            _offerDal = offerDal;
            _speCodeDal = speCodeDa;                
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
