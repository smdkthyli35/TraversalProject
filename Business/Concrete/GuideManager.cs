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
    public class GuideManager : ManagerBase, IGuideService
    {
        public GuideManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(GuideAddDto guideAddDto, string createdByName)
        {
            var guide = Mapper.Map<Guide>(guideAddDto);
            guide.CreatedByName = createdByName;
            guide.ModifiedByName = createdByName;
            await UnitOfWork.Guides.AddAsync(guide);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Guide.Add(guide.Name));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var guidesCount = await UnitOfWork.Guides.CountAsync();
            if (guidesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, guidesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var guidesCount = await UnitOfWork.Guides.CountAsync(g => !g.IsDeleted);
            if (guidesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, guidesCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int guideId, string modifiedByName)
        {
            var result = await UnitOfWork.Guides.AnyAsync(a => a.Id == guideId);
            if (result)
            {
                var guide = await UnitOfWork.Guides.GetAsync(a => a.Id == guideId);
                guide.IsDeleted = true;
                guide.ModifiedByName = modifiedByName;
                guide.ModifiedDate = DateTime.Now;
                await UnitOfWork.Guides.UpdateAsync(guide);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Guide.Delete(guide.Name));
            }
            return new Result(ResultStatus.Error, Messages.Guide.NotFound(isPlural: false));
        }

        public async Task<IDataResult<GuideListDto>> GetAllAsync()
        {
            var guides = await UnitOfWork.Guides.GetAllAsync();
            if (guides.Count > -1)
            {
                return new DataResult<GuideListDto>(ResultStatus.Success, new GuideListDto
                {
                    Guides = guides,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<GuideListDto>(ResultStatus.Error, Messages.Guide.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<GuideListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var guides = await UnitOfWork.Guides.GetAllAsync(g => !g.IsDeleted && g.IsActive);
            if (guides.Count > -1)
            {
                return new DataResult<GuideListDto>(ResultStatus.Success, new GuideListDto
                {
                    Guides = guides,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<GuideListDto>(ResultStatus.Error, Messages.Guide.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<GuideListDto>> GetAllByNonDeletedAsync()
        {
            var guides = await UnitOfWork.Guides.GetAllAsync(g => !g.IsDeleted);
            if (guides.Count > -1)
            {
                return new DataResult<GuideListDto>(ResultStatus.Success, new GuideListDto
                {
                    Guides = guides,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<GuideListDto>(ResultStatus.Error, Messages.Guide.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<GuideDto>> GetAsync(int guideId)
        {
            var guide = await UnitOfWork.Guides.GetAsync(a => a.Id == guideId);
            if (guide != null)
            {
                return new DataResult<GuideDto>(ResultStatus.Success, new GuideDto
                {
                    Guide = guide,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<GuideDto>(ResultStatus.Error, Messages.Guide.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int guideId)
        {
            var result = await UnitOfWork.Guides.AnyAsync(a => a.Id == guideId);
            if (result)
            {
                var guide = await UnitOfWork.Guides.GetAsync(a => a.Id == guideId);
                await UnitOfWork.Guides.DeleteAsync(guide);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Guide.HardDelete(guide.Name));
            }
            return new Result(ResultStatus.Error, Messages.Guide.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(GuideUpdateDto guideUpdateDto, string modifiedByName)
        {
            var oldGuide = await UnitOfWork.Guides.GetAsync(a => a.Id == guideUpdateDto.Id);
            var guide = Mapper.Map<GuideUpdateDto, Guide>(guideUpdateDto, oldGuide);
            guide.ModifiedByName = modifiedByName;
            await UnitOfWork.Guides.UpdateAsync(guide);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Guide.Update(guide.Name));
        }
    }
}
