using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.MASqlConnection;
using MotorAsinBasketRobot.Shared.Enums;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class MASqlConnectionManager : IMASqlConnectionService
    {
        private readonly IMASqlConnectionDal _mASqlConnectionDal;
        private readonly IMASqlConnectionValidator _mASqlConnectionValidator;
        public MASqlConnectionManager(IMASqlConnectionDal mASqlConnectionDal, ISpeCodeDal speCodeDal)
        {
            _mASqlConnectionDal = mASqlConnectionDal;
            _mASqlConnectionValidator = new MASqlConnectionValidator(_mASqlConnectionDal,speCodeDal);
        }
        public async Task<IDataResult<IList<MASqlConnection>>> GetList(MASqlConnectionListPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<MASqlConnection>>
                (await _mASqlConnectionDal.GetListAsync(b => b.IsActive == parameter.IsActive && b.EnmConnetion==parameter.Connecion, b => b.Id), Messages.MASqlConnectionGetAll);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<MASqlConnection>>(ex.Message);
            }
        }
        public async Task<IDataResult<MASqlConnection>> Create(MASqlConnection entity)
        {
            try
            {
                //await _mASqlConnectionValidator.CheckCreateAsync(entity.Code);
                return new SuccessDataResult<MASqlConnection>(await _mASqlConnectionDal.CreateAsync(entity), Messages.MASqlConnectionAdded);

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<MASqlConnection>(ex.Message);
            }
        }
        public Task<IDataResult<MASqlConnection>> Delete(MASqlConnection entity)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult<MASqlConnection>> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult<MASqlConnection>> Update(MASqlConnection entity)
        {
            throw new NotImplementedException();
        }
        //public async Task<IDataResult<MASqlConnection>> CustomerCodeAsync(string code, EnmConnetion customerServer)
        //{
        //    return await _mASqlConnectionDall.CustomerCodeAsync(code, customerServer);
        //}  => Bu böyle yazılmaz
        //public async Task<IDataResult<MASqlConnection>> CustomerCodeAsync(string code, EnmConnetion customerServer)
        //{
        //    try
        //    {
        //        return new SuccessDataResult<MASqlConnection>(
        //            await _mASqlConnectionDal.GetAsync(
        //                b => b.IsActive == true && b.EnmConnetion == customerServer && (b.CustomerCode == code || b.CustomerCode == "MODU")
        //            ),
        //            Messages.MASqlConnectionGetAll
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrorDataResult<MASqlConnection>(ex.Message);
        //    }
        //}
        public async Task<IDataResult<MASqlConnection>> CustomerCodeAsync(string code, EnmConnetion customerServer)
        {
            try
            {
                return new SuccessDataResult<MASqlConnection>
                (await _mASqlConnectionDal.GetAsync(
                     b => b.IsActive == true && b.EnmConnetion == customerServer && b.CustomerCode == code), Messages.MASqlConnectionGetAll);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<MASqlConnection>(ex.Message);
            }
        }
        Task<IDataResult<MASqlConnection>> IMASqlConnectionService.GetCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateConnections(string connString)
        {
            await _mASqlConnectionDal.UpdateConnectionString(connString);
        }
    }
}
