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
    public class FeatureManager : ManagerBase, IFeatureService
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(FeatureAddDto featureAddDto, string createdByName)
        {
            var feature = Mapper.Map<Feature>(featureAddDto);
            feature.CreatedByName = createdByName;
            feature.ModifiedByName = createdByName;
            await UnitOfWork.Features.AddAsync(feature);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Feature.Add(feature.Title));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var featuresCount = await UnitOfWork.Features.CountAsync();
            if (featuresCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, featuresCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var featuresCount = await UnitOfWork.Features.CountAsync(f => !f.IsDeleted);
            if (featuresCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, featuresCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int featureId, string modifiedByName)
        {
            var result = await UnitOfWork.Features.AnyAsync(a => a.Id == featureId);
            if (result)
            {
                var feature = await UnitOfWork.Features.GetAsync(a => a.Id == featureId);
                feature.IsDeleted = true;
                feature.ModifiedByName = modifiedByName;
                feature.ModifiedDate = DateTime.Now;
                await UnitOfWork.Features.UpdateAsync(feature);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Feature.Delete(feature.Title));
            }
            return new Result(ResultStatus.Error, Messages.Feature.NotFound(isPlural: false));
        }

        public async Task<IDataResult<FeatureListDto>> GetAllAsync()
        {
            var features = await UnitOfWork.Features.GetAllAsync();
            if (features.Count > -1)
            {
                return new DataResult<FeatureListDto>(ResultStatus.Success, new FeatureListDto
                {
                    Features = features,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<FeatureListDto>(ResultStatus.Error, Messages.Feature.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<FeatureListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var features = await UnitOfWork.Features.GetAllAsync(f => !f.IsDeleted && f.IsActive);
            if (features.Count > -1)
            {
                return new DataResult<FeatureListDto>(ResultStatus.Success, new FeatureListDto
                {
                    Features = features,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<FeatureListDto>(ResultStatus.Error, Messages.Feature.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<FeatureListDto>> GetAllByNonDeletedAsync()
        {
            var features = await UnitOfWork.Features.GetAllAsync(f => !f.IsDeleted);
            if (features.Count > -1)
            {
                return new DataResult<FeatureListDto>(ResultStatus.Success, new FeatureListDto
                {
                    Features = features,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<FeatureListDto>(ResultStatus.Error, Messages.Feature.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<FeatureDto>> GetAsync(int featureId)
        {
            var feature = await UnitOfWork.Features.GetAsync(a => a.Id == featureId);
            if (feature != null)
            {
                return new DataResult<FeatureDto>(ResultStatus.Success, new FeatureDto
                {
                    Feature = feature,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<FeatureDto>(ResultStatus.Error, Messages.Feature.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int featureId)
        {
            var result = await UnitOfWork.Features.AnyAsync(a => a.Id == featureId);
            if (result)
            {
                var feature = await UnitOfWork.Features.GetAsync(a => a.Id == featureId);
                await UnitOfWork.Features.DeleteAsync(feature);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Feature.HardDelete(feature.Title));
            }
            return new Result(ResultStatus.Error, Messages.Feature.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(FeatureUpdateDto featureUpdateDto, string modifiedByName)
        {
            var oldFeature = await UnitOfWork.Features.GetAsync(a => a.Id == featureUpdateDto.Id);
            var feature = Mapper.Map<FeatureUpdateDto, Feature>(featureUpdateDto, oldFeature);
            feature.ModifiedByName = modifiedByName;
            await UnitOfWork.Features.UpdateAsync(feature);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Feature.Update(feature.Title));
        }
    }
}
