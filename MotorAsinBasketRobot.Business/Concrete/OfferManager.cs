using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class OfferManager:IOfferService
    {
        private readonly IOfferDal _offerDal;
        private readonly IOfferValidator _offerValidator;
        public OfferManager(IOfferDal offerDal, ISpeCodeDal speCodeDal)
        {
            _offerDal = offerDal;
            _offerValidator = new OfferValidator(_offerDal, speCodeDal);
        }

        public Task<IDataResult<Offer>> Create(Offer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Offer>> Delete(Offer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Offer>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IDataResult<IList<Offer>>> GetList(OfferListPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<Offer>>
                    (await _offerDal.GetListAsync(b => b.IsActive == parameter.IsActive, b => b.Id), Messages.Offergetall);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<IDataResult<Offer>> Update(Offer entity)
        {
            throw new NotImplementedException();
        }
    }
}
