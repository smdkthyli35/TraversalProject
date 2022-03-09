using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewsletterService
    {
        Task<IDataResult<NewsletterDto>> GetAsync(int newsletterId);
        Task<IDataResult<NewsletterListDto>> GetAllAsync();
        Task<IDataResult<NewsletterListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<NewsletterListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(NewsletterAddDto newsletterAddDto, string createdByName);
        Task<IResult> UpdateAsync(NewsletterUpdateDto newsletterUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int newsletterId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int newsletterId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
