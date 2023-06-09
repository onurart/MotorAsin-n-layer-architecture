using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Business.Abstract;
using MotorAsinBasketRobot.Business.Constants;
using MotorAsinBasketRobot.Business.Validator.Abstract;
using MotorAsinBasketRobot.Business.Validator.Concrete;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Concrete
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentsDal _documentDal;
        private readonly IDocumentValidator _documentValidator;

        public DocumentManager(IDocumentsDal documentDal, ISpeCodeDal speCodeDal)
        {
            _documentDal = documentDal;
            _documentValidator = new DocumentValidator(_documentDal, speCodeDal);
        }

        public async Task<IDataResult<Documents>> Create(Documents entity)
        {
            try
            {
               // await _documentValidator.CheckCreateAsync(entity.Code);
                return new SuccessDataResult<Documents>(await _documentDal.CreateAsync(entity), Messages.DocumentAdded);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Documents>(ex.Message);
            }
        }

        public async Task<IDataResult<Documents>> Delete(Documents entity)
        {
            try
            {
                return new SuccessDataResult<Documents>(await _documentDal.DeleteAsync(entity), Messages.DocumentDeleted);

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Documents>(ex.Message);
            }
        }

        public async Task<IDataResult<Documents>> Get(int id)
        {
            try
            {
                return new SuccessDataResult<Documents>(await _documentDal.GetAsync(id, b => b.Id == id, b => b.Id), Messages.DocumentGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Documents>(ex.Message);
            }
        }

        public async Task<IList<Documents>> GetBatchedList(DocumentListPramertDto dto, int startIndex, int batchSize)
        {
            // İstenilen sayfa aralığında belgeleri getirmek için gerekli işlemleri gerçekleştirin
            // startIndex parametresi ile belirtilen indeksten başlayarak batchSize parametresi kadar belge döndürün

            try
            {
                // Belge listesini depolayan bir koleksiyon oluşturun
                var documentList = new List<Documents>();

                // Belge verilerini veritabanından veya başka bir kaynaktan alın
                // İşleminizi yaparken veritabanı bağlantısı, Entity Framework veya başka bir ORM kullanabilirsiniz
                // Aşağıda örnek bir veritabanı sorgusu yapılıyor gibi gösterilmiştir, gerçek sorgu yapısını kendi senaryonuza göre düzenlemeniz gerekmektedir

                using (var dbContext = new AppDbContext())
                {
                    var query = dbContext.Documents
                        .Where(d =>(bool)d.IsActive /* Belirli bir kriteri sağlayan belgeleri filtreleyin, dto parametresini kullanabilirsiniz */)
                        .OrderBy(d => d.Id /* Belge listesini belirli bir özelliğe göre sıralayın, istediğiniz sıralama ifadesini kullanabilirsiniz */)
                        .Skip(startIndex)
                        .Take(batchSize);

                    // Belge verilerini asenkron olarak alın
                    var documents = await query.ToListAsync();

                    // Aldığınız belge verilerini documentList koleksiyonuna ekleyin
                    documentList.AddRange(documents);
                }

                // İşlem başarılı olduğunda belge listesini döndürün
                return documentList;
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemleri gerçekleştirin veya istisna yeniden fırlatın
                throw ex;
            }
        }


        public async Task<IDataResult<string>> GetCode(DocumentCodeParameterDto parameter)
        {
            try
            {
                return new SuccessDataResult<string>(await _documentDal.GetCodeAsync(x => x.DocumentNo, b => b.IsActive == parameter.Statu), Messages.DocumentGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<string>("", ex.Message);
            }
        }
        public async Task<IDataResult<IList<Documents>>> GetList(DocumentListPramertDto parameter)
        {
            try
            {
                return new SuccessDataResult<IList<Documents>>
                (await _documentDal.GetListAsync(b => b.IsActive == parameter.IsActive, b => b.Id), Messages.DocumentGetAll);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Documents>>(ex.Message);
            }
        }
      
        
        public async Task<int> GetTotalCount(DocumentListPramertDto dto)
        {
            using (var dbContext = new AppDbContext())
            {
                int totalCount = await dbContext.Documents
                    .Where(d =>(bool)d.IsActive /* Belirli bir kriteri sağlayan belgeleri filtreleyin, dto parametresini kullanabilirsiniz */)
                    .CountAsync();

                return totalCount;
            }
        }

        public async Task<IDataResult<Documents>> Update(Documents entity)
        {
            try
            {
            //   await _documentValidator.CheckUpdateAsync(entity.Id, entity.Id, entity);
                return new SuccessDataResult<Documents>(await _documentDal.UpdateAsync(entity), Messages.DocumentUpdated);

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Documents>(entity, ex.Message);
            }
        }
    }
}
