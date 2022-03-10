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
    public class NewsletterManager : ManagerBase, INewsletterService
    {
        public NewsletterManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(NewsletterAddDto newsletterAddDto, string createdByName)
        {
            var newsletter = Mapper.Map<Newsletter>(newsletterAddDto);
            newsletter.CreatedByName = createdByName;
            newsletter.ModifiedByName = createdByName;
            await UnitOfWork.Newsletters.AddAsync(newsletter);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Newsletter.Add(newsletter.Mail));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var newslettersCount = await UnitOfWork.Newsletters.CountAsync();
            if (newslettersCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, newslettersCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var newslettersCount = await UnitOfWork.Newsletters.CountAsync(n => !n.IsDeleted);
            if (newslettersCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, newslettersCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int newsletterId, string modifiedByName)
        {
            var result = await UnitOfWork.Newsletters.AnyAsync(a => a.Id == newsletterId);
            if (result)
            {
                var newsletter = await UnitOfWork.Newsletters.GetAsync(a => a.Id == newsletterId);
                newsletter.IsDeleted = true;
                newsletter.ModifiedByName = modifiedByName;
                newsletter.ModifiedDate = DateTime.Now;
                await UnitOfWork.Newsletters.UpdateAsync(newsletter);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Newsletter.Delete(newsletter.Mail));
            }
            return new Result(ResultStatus.Error, Messages.Newsletter.NotFound(isPlural: false));
        }

        public async Task<IDataResult<NewsletterListDto>> GetAllAsync()
        {
            var newsletters = await UnitOfWork.Newsletters.GetAllAsync();
            if (newsletters.Count > -1)
            {
                return new DataResult<NewsletterListDto>(ResultStatus.Success, new NewsletterListDto
                {
                    Newsletters = newsletters,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<NewsletterListDto>(ResultStatus.Error, Messages.Newsletter.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<NewsletterListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var newsletters = await UnitOfWork.Newsletters.GetAllAsync(n => !n.IsDeleted && n.IsActive);
            if (newsletters.Count > -1)
            {
                return new DataResult<NewsletterListDto>(ResultStatus.Success, new NewsletterListDto
                {
                    Newsletters = newsletters,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<NewsletterListDto>(ResultStatus.Error, Messages.Newsletter.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<NewsletterListDto>> GetAllByNonDeletedAsync()
        {
            var newsletters = await UnitOfWork.Newsletters.GetAllAsync(n => !n.IsDeleted);
            if (newsletters.Count > -1)
            {
                return new DataResult<NewsletterListDto>(ResultStatus.Success, new NewsletterListDto
                {
                    Newsletters = newsletters,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<NewsletterListDto>(ResultStatus.Error, Messages.Newsletter.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<NewsletterDto>> GetAsync(int newsletterId)
        {
            var newsletter = await UnitOfWork.Newsletters.GetAsync(a => a.Id == newsletterId);
            if (newsletter != null)
            {
                return new DataResult<NewsletterDto>(ResultStatus.Success, new NewsletterDto
                {
                    Newsletter = newsletter,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<NewsletterDto>(ResultStatus.Error, Messages.Newsletter.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int newsletterId)
        {
            var result = await UnitOfWork.Newsletters.AnyAsync(a => a.Id == newsletterId);
            if (result)
            {
                var newsletter = await UnitOfWork.Newsletters.GetAsync(a => a.Id == newsletterId);
                await UnitOfWork.Newsletters.DeleteAsync(newsletter);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Newsletter.HardDelete(newsletter.Mail));
            }
            return new Result(ResultStatus.Error, Messages.Newsletter.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(NewsletterUpdateDto newsletterUpdateDto, string modifiedByName)
        {
            var oldNewsletter = await UnitOfWork.Newsletters.GetAsync(a => a.Id == newsletterUpdateDto.Id);
            var newsletter = Mapper.Map<NewsletterUpdateDto, Newsletter>(newsletterUpdateDto, oldNewsletter);
            newsletter.ModifiedByName = modifiedByName;
            await UnitOfWork.Newsletters.UpdateAsync(newsletter);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Newsletter.Update(newsletter.Mail));
        }
    }
}
