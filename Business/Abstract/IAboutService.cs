using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        Task<IDataResult<AboutDto>> GetAsync(int aboutId);
        Task<IDataResult<AboutListDto>> GetAllAsync();
        Task<IDataResult<AboutListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<AboutListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(AboutAddDto aboutAddDto, string createdByName);
        Task<IResult> UpdateAsync(AboutUpdateDto aboutUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int aboutId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int aboutId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
