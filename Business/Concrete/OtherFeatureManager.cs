using AutoMapper;
using Business.Abstract;
using Business.Utilities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OtherFeatureManager : ManagerBase, IOtherFeatureService
    {
        public OtherFeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(OtherFeatureAddDto otherFeatureAddDto, string createdByName)
        {
            var otherFeature = Mapper.Map<OtherFeature>(otherFeatureAddDto);
            otherFeature.CreatedByName = createdByName;
            otherFeature.ModifiedByName = createdByName;
            await UnitOfWork.OtherFeatures.AddAsync(otherFeature);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.OtherFeature.Add(otherFeature.Title));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var otherFeaturesCount = await UnitOfWork.OtherFeatures.CountAsync();
            if (otherFeaturesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, otherFeaturesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var otherFeaturesCount = await UnitOfWork.OtherFeatures.CountAsync(o => !o.IsDeleted);
            if (otherFeaturesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, otherFeaturesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int otherFeatureId, string modifiedByName)
        {
            var result = await UnitOfWork.OtherFeatures.AnyAsync(a => a.Id == otherFeatureId);
            if (result)
            {
                var otherFeature = await UnitOfWork.OtherFeatures.GetAsync(a => a.Id == otherFeatureId);
                otherFeature.IsDeleted = true;
                otherFeature.ModifiedByName = modifiedByName;
                otherFeature.ModifiedDate = DateTime.Now;
                await UnitOfWork.OtherFeatures.UpdateAsync(otherFeature);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.OtherFeature.Delete(otherFeature.Title));
            }
            return new Result(ResultStatus.Error, Messages.OtherFeature.NotFound(isPlural: false));
        }

        public async Task<IDataResult<OtherFeatureListDto>> GetAllAsync()
        {
            var otherFeatures = await UnitOfWork.OtherFeatures.GetAllAsync();
            if (otherFeatures.Count > -1)
            {
                return new DataResult<OtherFeatureListDto>(ResultStatus.Success, new OtherFeatureListDto
                {
                    OtherFeatures = otherFeatures,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<OtherFeatureListDto>(ResultStatus.Error, Messages.OtherFeature.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OtherFeatureListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var otherFeatures = await UnitOfWork.OtherFeatures.GetAllAsync(o => !o.IsDeleted && o.IsActive);
            if (otherFeatures.Count > -1)
            {
                return new DataResult<OtherFeatureListDto>(ResultStatus.Success, new OtherFeatureListDto
                {
                    OtherFeatures = otherFeatures,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<OtherFeatureListDto>(ResultStatus.Error, Messages.OtherFeature.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OtherFeatureListDto>> GetAllByNonDeletedAsync()
        {
            var otherFeatures = await UnitOfWork.OtherFeatures.GetAllAsync(o => !o.IsDeleted);
            if (otherFeatures.Count > -1)
            {
                return new DataResult<OtherFeatureListDto>(ResultStatus.Success, new OtherFeatureListDto
                {
                    OtherFeatures = otherFeatures,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<OtherFeatureListDto>(ResultStatus.Error, Messages.OtherFeature.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OtherFeatureDto>> GetAsync(int otherFeatureId)
        {
            var otherFeature = await UnitOfWork.OtherFeatures.GetAsync(a => a.Id == otherFeatureId);
            if (otherFeature != null)
            {
                return new DataResult<OtherFeatureDto>(ResultStatus.Success, new OtherFeatureDto
                {
                    OtherFeature = otherFeature,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<OtherFeatureDto>(ResultStatus.Error, Messages.OtherFeature.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int otherFeatureId)
        {
            var result = await UnitOfWork.OtherFeatures.AnyAsync(a => a.Id == otherFeatureId);
            if (result)
            {
                var otherFeature = await UnitOfWork.OtherFeatures.GetAsync(a => a.Id == otherFeatureId);
                await UnitOfWork.OtherFeatures.DeleteAsync(otherFeature);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.OtherFeature.HardDelete(otherFeature.Title));
            }
            return new Result(ResultStatus.Error, Messages.OtherFeature.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(OtherFeatureUpdateDto otherFeatureUpdateDto, string modifiedByName)
        {
            var oldOtherFeature = await UnitOfWork.OtherFeatures.GetAsync(a => a.Id == otherFeatureUpdateDto.Id);
            var otherFeature = Mapper.Map<OtherFeatureUpdateDto, OtherFeature>(otherFeatureUpdateDto, oldOtherFeature);
            otherFeature.ModifiedByName = modifiedByName;
            await UnitOfWork.OtherFeatures.UpdateAsync(otherFeature);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.OtherFeature.Update(otherFeature.Title));
        }
    }
}
