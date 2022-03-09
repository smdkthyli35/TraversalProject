using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        Task<IDataResult<TestimonialDto>> GetAsync(int testimonialId);
        Task<IDataResult<TestimonialListDto>> GetAllAsync();
        Task<IDataResult<TestimonialListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<TestimonialListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(TestimonialAddDto testimonialAddDto, string createdByName);
        Task<IResult> UpdateAsync(TestimonialUpdateDto testimonialUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int testimonialId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int testimonialId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
