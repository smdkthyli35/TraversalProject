using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOtherFeatureService
    {
        Task<IDataResult<OtherFeatureDto>> GetAsync(int otherFeatureId);
        Task<IDataResult<OtherFeatureListDto>> GetAllAsync();
        Task<IDataResult<OtherFeatureListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<OtherFeatureListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(OtherFeatureAddDto otherFeatureAddDto, string createdByName);
        Task<IResult> UpdateAsync(OtherFeatureUpdateDto otherFeatureUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int otherFeatureId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int otherFeatureId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
