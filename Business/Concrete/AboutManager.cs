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
    public class AboutManager : ManagerBase, IAboutService
    {
        public AboutManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(AboutAddDto aboutAddDto, string createdByName)
        {
            var about = Mapper.Map<About>(aboutAddDto);
            about.CreatedByName = createdByName;
            about.ModifiedByName = createdByName;
            await UnitOfWork.Abouts.AddAsync(about);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.About.Add(about.FirstTitle, about.SecondTitle));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var aboutsCount = await UnitOfWork.Abouts.CountAsync();
            if (aboutsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, aboutsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var aboutsCount = await UnitOfWork.Abouts.CountAsync(a => !a.IsDeleted);
            if (aboutsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, aboutsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int aboutId, string modifiedByName)
        {
            var result = await UnitOfWork.Abouts.AnyAsync(a => a.Id == aboutId);
            if (result)
            {
                var about = await UnitOfWork.Abouts.GetAsync(a => a.Id == aboutId);
                about.IsDeleted = true;
                about.ModifiedByName = modifiedByName;
                about.ModifiedDate = DateTime.Now;
                await UnitOfWork.Abouts.UpdateAsync(about);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.About.Delete(about.FirstTitle, about.SecondTitle));
            }
            return new Result(ResultStatus.Error, Messages.About.NotFound(isPlural: false));
        }

        public async Task<IDataResult<AboutListDto>> GetAllAsync()
        {
            var abouts = await UnitOfWork.Abouts.GetAllAsync();
            if (abouts.Count > -1)
            {
                return new DataResult<AboutListDto>(ResultStatus.Success, new AboutListDto
                {
                    Abouts = abouts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutListDto>(ResultStatus.Error, Messages.About.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AboutListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var abouts = await UnitOfWork.Abouts.GetAllAsync(a => !a.IsDeleted && a.IsActive);
            if (abouts.Count > -1)
            {
                return new DataResult<AboutListDto>(ResultStatus.Success, new AboutListDto
                {
                    Abouts = abouts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutListDto>(ResultStatus.Error, Messages.About.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AboutListDto>> GetAllByNonDeletedAsync()
        {
            var abouts = await UnitOfWork.Abouts.GetAllAsync(a => !a.IsDeleted);
            if (abouts.Count > -1)
            {
                return new DataResult<AboutListDto>(ResultStatus.Success, new AboutListDto
                {
                    Abouts = abouts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutListDto>(ResultStatus.Error, Messages.About.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<AboutDto>> GetAsync(int aboutId)
        {
            var about = await UnitOfWork.Abouts.GetAsync(a => a.Id == aboutId);
            if (about != null)
            {
                return new DataResult<AboutDto>(ResultStatus.Success, new AboutDto
                {
                    About = about,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<AboutDto>(ResultStatus.Error, Messages.About.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int aboutId)
        {
            var result = await UnitOfWork.Abouts.AnyAsync(a => a.Id == aboutId);
            if (result)
            {
                var about = await UnitOfWork.Abouts.GetAsync(a => a.Id == aboutId);
                await UnitOfWork.Abouts.DeleteAsync(about);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.About.HardDelete(about.FirstTitle, about.SecondTitle));
            }
            return new Result(ResultStatus.Error, Messages.About.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(AboutUpdateDto aboutUpdateDto, string modifiedByName)
        {
            var oldAbout = await UnitOfWork.Abouts.GetAsync(a => a.Id == aboutUpdateDto.Id);
            var about = Mapper.Map<AboutUpdateDto, About>(aboutUpdateDto, oldAbout);
            about.ModifiedByName = modifiedByName;
            await UnitOfWork.Abouts.UpdateAsync(about);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.About.Update(about.FirstTitle, about.SecondTitle));
        }
    }
}
