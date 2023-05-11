using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICustomerValidator _customerValidator;

        public CustomerManager(ICustomerDal customerDal, ISpeCodeDal speCodeDal)
        {
            _customerDal = customerDal;
            _customerValidator = new CustomerValidator(_customerDal, speCodeDal);
        }

        public async Task<IDataResult<Customer>> Create(Customer entity)
        {
            try
            {
              //  await _customerValidator.CheckCreateAsync(entity.Code);
                return new SuccessDataResult<Customer>(await _customerDal.CreateAsync(entity), Messages.CustomerAdded);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(ex.Message);
            }
        }

        public async Task<IDataResult<Customer>> Delete(Customer entity)
        {
            try
            {
                return  new SuccessDataResult<Customer>(await _customerDal.DeleteAsync(entity),Messages.CustomerDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(ex.Message);
            }
        }

        public async Task<IDataResult<Customer>> Get(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>(await _customerDal.GetAsync(id, b => b.Id == id, b => b.Id), Messages.ProductGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(ex.Message);
            }
        }

        public async Task<IDataResult<string>> GetCode(CustomerCodeParameterDto parameterDto)
        {
            try
            {
                return new SuccessDataResult<string>(await _customerDal.GetCodeAsync(x => x.CustomerCode, b => b.IsActive == parameterDto.Statu), Messages.ProductGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>("", ex.Message);
            }
        }

        public async Task<IDataResult<IList<Customer>>> GetList(CustomerListPramertDto parameterDto)
        {
            try 
            {
                return new SuccessDataResult<IList<Customer>>
                    (await _customerDal.GetListAsync(x => x.IsActive == parameterDto.IsActive, x => x.IsActive), Messages.CustomerGetAll);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IDataResult<Customer>> Update(Customer entity)
        {
            try
            {
                //await _customerValidator.CheckUpdateAsync(entity.Id, entity.Id, entity);
                return new SuccessDataResult<Customer>(await _customerDal.UpdateAsync(entity), Messages.ProductUpdated);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(entity, ex.Message);
            }
        }
    }
}
