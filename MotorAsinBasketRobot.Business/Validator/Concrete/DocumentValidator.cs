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
    public class DocumentValidator : IDocumentValidator
    {
        private readonly IDocumentsDal _documentsDal;
        private readonly ISpeCodeDal _speCodeDal;

        public DocumentValidator(IDocumentsDal documentsDal, ISpeCodeDal speCodeDal)
        {
            _documentsDal = documentsDal;
            _speCodeDal = speCodeDal;
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
