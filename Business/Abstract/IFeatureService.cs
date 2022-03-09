using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeatureService
    {
        Task<IDataResult<FeatureDto>> GetAsync(int featureId);
        Task<IDataResult<FeatureListDto>> GetAllAsync();
        Task<IDataResult<FeatureListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<FeatureListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(FeatureAddDto featureAddDto, string createdByName);
        Task<IResult> UpdateAsync(FeatureUpdateDto featureUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int featureId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int featureId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
