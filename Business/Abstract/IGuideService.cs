using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGuideService
    {
        Task<IDataResult<GuideDto>> GetAsync(int guideId);
        Task<IDataResult<GuideListDto>> GetAllAsync();
        Task<IDataResult<GuideListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<GuideListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(GuideAddDto guideAddDto, string createdByName);
        Task<IResult> UpdateAsync(GuideUpdateDto guideUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int guideId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int guideId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
