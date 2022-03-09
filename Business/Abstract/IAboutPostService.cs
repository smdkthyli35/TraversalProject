using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutPostService
    {
        Task<IDataResult<AboutPostDto>> GetAsync(int aboutPostId);
        Task<IDataResult<AboutPostListDto>> GetAllAsync();
        Task<IDataResult<AboutPostListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<AboutPostListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(AboutPostAddDto aboutPostAddDto, string createdByName);
        Task<IResult> UpdateAsync(AboutPostUpdateDto aboutPostUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int aboutPostId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int aboutPostId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
