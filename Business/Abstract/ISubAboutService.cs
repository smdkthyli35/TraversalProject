using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubAboutService
    {
        Task<IDataResult<SubAboutDto>> GetAsync(int subAboutId);
        Task<IDataResult<SubAboutListDto>> GetAllAsync();
        Task<IDataResult<SubAboutListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<SubAboutListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(SubAboutAddDto subAboutAddDto, string createdByName);
        Task<IResult> UpdateAsync(SubAboutUpdateDto subAboutUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int subAboutId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int subAboutId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
