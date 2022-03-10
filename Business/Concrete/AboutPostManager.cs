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
    public class AboutPostManager : ManagerBase, IAboutPostService
    {
        public AboutPostManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(AboutPostAddDto aboutPostAddDto, string createdByName)
        {
            var aboutPost = Mapper.Map<AboutPost>(aboutPostAddDto);
            aboutPost.CreatedByName = createdByName;
            aboutPost.ModifiedByName = createdByName;
            await UnitOfWork.AboutPosts.AddAsync(aboutPost);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.AboutPost.Add(aboutPost.FirstTitle, aboutPost.SecondTitle));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var aboutPostsCount = await UnitOfWork.AboutPosts.CountAsync();
            if (aboutPostsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, aboutPostsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var aboutPostsCount = await UnitOfWork.AboutPosts.CountAsync(a => !a.IsDeleted);
            if (aboutPostsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, aboutPostsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int aboutPostId, string modifiedByName)
        {
            var result = await UnitOfWork.AboutPosts.AnyAsync(a => a.Id == aboutPostId);
            if (result)
            {
                var aboutPost = await UnitOfWork.AboutPosts.GetAsync(a => a.Id == aboutPostId);
                aboutPost.IsDeleted = true;
                aboutPost.ModifiedByName = modifiedByName;
                aboutPost.ModifiedDate = DateTime.Now;
                await UnitOfWork.AboutPosts.UpdateAsync(aboutPost);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.AboutPost.Delete(aboutPost.FirstTitle, aboutPost.SecondTitle));
            }
            return new Result(ResultStatus.Error, Messages.AboutPost.NotFound(isPlural: false));
        }

        public async Task<IDataResult<AboutPostListDto>> GetAllAsync()
        {
            var aboutPosts = await UnitOfWork.AboutPosts.GetAllAsync();
            if (aboutPosts.Count > -1)
            {
                return new DataResult<AboutPostListDto>(ResultStatus.Success, new AboutPostListDto
                {
                    AboutPosts = aboutPosts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutPostListDto>(ResultStatus.Error, Messages.AboutPost.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AboutPostListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var aboutPosts = await UnitOfWork.AboutPosts.GetAllAsync(a => !a.IsDeleted && a.IsActive);
            if (aboutPosts.Count > -1)
            {
                return new DataResult<AboutPostListDto>(ResultStatus.Success, new AboutPostListDto
                {
                    AboutPosts = aboutPosts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutPostListDto>(ResultStatus.Error, Messages.AboutPost.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AboutPostListDto>> GetAllByNonDeletedAsync()
        {
            var aboutPosts = await UnitOfWork.AboutPosts.GetAllAsync(a => !a.IsDeleted);
            if (aboutPosts.Count > -1)
            {
                return new DataResult<AboutPostListDto>(ResultStatus.Success, new AboutPostListDto
                {
                    AboutPosts = aboutPosts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutPostListDto>(ResultStatus.Error, Messages.AboutPost.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AboutPostDto>> GetAsync(int aboutPostId)
        {
            var aboutPost = await UnitOfWork.AboutPosts.GetAsync(a => a.Id == aboutPostId);
            if (aboutPost != null)
            {
                return new DataResult<AboutPostDto>(ResultStatus.Success, new AboutPostDto
                {
                    AboutPost = aboutPost,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutPostDto>(ResultStatus.Error, Messages.AboutPost.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int aboutPostId)
        {
            var result = await UnitOfWork.AboutPosts.AnyAsync(a => a.Id == aboutPostId);
            if (result)
            {
                var aboutPost = await UnitOfWork.AboutPosts.GetAsync(a => a.Id == aboutPostId);
                await UnitOfWork.AboutPosts.DeleteAsync(aboutPost);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.AboutPost.HardDelete(aboutPost.FirstTitle, aboutPost.SecondTitle));
            }
            return new Result(ResultStatus.Error, Messages.AboutPost.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(AboutPostUpdateDto aboutPostUpdateDto, string modifiedByName)
        {
            var oldAboutPost = await UnitOfWork.AboutPosts.GetAsync(a => a.Id == aboutPostUpdateDto.Id);
            var aboutPost = Mapper.Map<AboutPostUpdateDto, AboutPost>(aboutPostUpdateDto, oldAboutPost);
            aboutPost.ModifiedByName = modifiedByName;
            await UnitOfWork.AboutPosts.UpdateAsync(aboutPost);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.AboutPost.Update(aboutPost.FirstTitle, aboutPost.SecondTitle));
        }
    }
}
