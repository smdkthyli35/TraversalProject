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
    public class SubAboutManager : ManagerBase, ISubAboutService
    {
        public SubAboutManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(SubAboutAddDto subAboutAddDto, string createdByName)
        {
            var subAbout = Mapper.Map<SubAbout>(subAboutAddDto);
            subAbout.CreatedByName = createdByName;
            subAbout.ModifiedByName = createdByName;
            await UnitOfWork.SubAbouts.AddAsync(subAbout);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.SubAbout.Add(subAbout.Title));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var subAboutsCount = await UnitOfWork.SubAbouts.CountAsync();
            if (subAboutsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, subAboutsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var subAboutsCount = await UnitOfWork.SubAbouts.CountAsync(s => !s.IsDeleted);
            if (subAboutsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, subAboutsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int subAboutId, string modifiedByName)
        {
            var result = await UnitOfWork.SubAbouts.AnyAsync(a => a.Id == subAboutId);
            if (result)
            {
                var subAbout = await UnitOfWork.SubAbouts.GetAsync(a => a.Id == subAboutId);
                subAbout.IsDeleted = true;
                subAbout.ModifiedByName = modifiedByName;
                subAbout.ModifiedDate = DateTime.Now;
                await UnitOfWork.SubAbouts.UpdateAsync(subAbout);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.SubAbout.Delete(subAbout.Title));
            }
            return new Result(ResultStatus.Error, Messages.SubAbout.NotFound(isPlural: false));
        }

        public async Task<IDataResult<SubAboutListDto>> GetAllAsync()
        {
            var subAbouts = await UnitOfWork.SubAbouts.GetAllAsync();
            if (subAbouts.Count > -1)
            {
                return new DataResult<SubAboutListDto>(ResultStatus.Success, new SubAboutListDto
                {
                    SubAbouts = subAbouts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SubAboutListDto>(ResultStatus.Error, Messages.SubAbout.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<SubAboutListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var subAbouts = await UnitOfWork.SubAbouts.GetAllAsync(s => !s.IsDeleted && s.IsActive);
            if (subAbouts.Count > -1)
            {
                return new DataResult<SubAboutListDto>(ResultStatus.Success, new SubAboutListDto
                {
                    SubAbouts = subAbouts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SubAboutListDto>(ResultStatus.Error, Messages.SubAbout.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<SubAboutListDto>> GetAllByNonDeletedAsync()
        {
            var subAbouts = await UnitOfWork.SubAbouts.GetAllAsync(s => !s.IsDeleted);
            if (subAbouts.Count > -1)
            {
                return new DataResult<SubAboutListDto>(ResultStatus.Success, new SubAboutListDto
                {
                    SubAbouts = subAbouts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SubAboutListDto>(ResultStatus.Error, Messages.SubAbout.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<SubAboutDto>> GetAsync(int subAboutId)
        {
            var subAbout = await UnitOfWork.SubAbouts.GetAsync(a => a.Id == subAboutId);
            if (subAbout != null)
            {
                return new DataResult<SubAboutDto>(ResultStatus.Success, new SubAboutDto
                {
                    SubAbout = subAbout,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<SubAboutDto>(ResultStatus.Error, Messages.SubAbout.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int subAboutId)
        {
            var result = await UnitOfWork.SubAbouts.AnyAsync(a => a.Id == subAboutId);
            if (result)
            {
                var subAbout = await UnitOfWork.SubAbouts.GetAsync(a => a.Id == subAboutId);
                await UnitOfWork.SubAbouts.DeleteAsync(subAbout);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.SubAbout.HardDelete(subAbout.Title));
            }
            return new Result(ResultStatus.Error, Messages.SubAbout.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(SubAboutUpdateDto subAboutUpdateDto, string modifiedByName)
        {
            var oldSubAbout = await UnitOfWork.SubAbouts.GetAsync(a => a.Id == subAboutUpdateDto.Id);
            var subAbout = Mapper.Map<SubAboutUpdateDto, SubAbout>(subAboutUpdateDto, oldSubAbout);
            subAbout.ModifiedByName = modifiedByName;
            await UnitOfWork.SubAbouts.UpdateAsync(subAbout);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.SubAbout.Update(subAbout.Title));
        }
    }
}
