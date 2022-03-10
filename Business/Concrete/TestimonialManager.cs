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
    public class TestimonialManager : ManagerBase, ITestimonialService
    {
        public TestimonialManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(TestimonialAddDto testimonialAddDto, string createdByName)
        {
            var testimonial = Mapper.Map<Testimonial>(testimonialAddDto);
            testimonial.CreatedByName = createdByName;
            testimonial.ModifiedByName = createdByName;
            await UnitOfWork.Testimonials.AddAsync(testimonial);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Testimonial.Add);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var testimonialsCount = await UnitOfWork.Testimonials.CountAsync();
            if (testimonialsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, testimonialsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var testimonialsCount = await UnitOfWork.Testimonials.CountAsync(t => !t.IsDeleted);
            if (testimonialsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, testimonialsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int testimonialId, string modifiedByName)
        {
            var result = await UnitOfWork.Testimonials.AnyAsync(a => a.Id == testimonialId);
            if (result)
            {
                var testimonial = await UnitOfWork.Testimonials.GetAsync(a => a.Id == testimonialId);
                testimonial.IsDeleted = true;
                testimonial.ModifiedByName = modifiedByName;
                testimonial.ModifiedDate = DateTime.Now;
                await UnitOfWork.Testimonials.UpdateAsync(testimonial);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Testimonial.Delete);
            }
            return new Result(ResultStatus.Error, Messages.Testimonial.NotFound(isPlural: false));
        }

        public async Task<IDataResult<TestimonialListDto>> GetAllAsync()
        {
            var testimonials = await UnitOfWork.Testimonials.GetAllAsync();
            if (testimonials.Count > -1)
            {
                return new DataResult<TestimonialListDto>(ResultStatus.Success, new TestimonialListDto
                {
                    Testimonials = testimonials,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TestimonialListDto>(ResultStatus.Error, Messages.Testimonial.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<TestimonialListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var testimonials = await UnitOfWork.Testimonials.GetAllAsync(t => !t.IsDeleted && t.IsActive);
            if (testimonials.Count > -1)
            {
                return new DataResult<TestimonialListDto>(ResultStatus.Success, new TestimonialListDto
                {
                    Testimonials = testimonials,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TestimonialListDto>(ResultStatus.Error, Messages.Testimonial.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<TestimonialListDto>> GetAllByNonDeletedAsync()
        {
            var testimonials = await UnitOfWork.Testimonials.GetAllAsync(t => !t.IsDeleted);
            if (testimonials.Count > -1)
            {
                return new DataResult<TestimonialListDto>(ResultStatus.Success, new TestimonialListDto
                {
                    Testimonials = testimonials,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TestimonialListDto>(ResultStatus.Error, Messages.Testimonial.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<TestimonialDto>> GetAsync(int testimonialId)
        {
            var testimonial = await UnitOfWork.Testimonials.GetAsync(a => a.Id == testimonialId);
            if (testimonial != null)
            {
                return new DataResult<TestimonialDto>(ResultStatus.Success, new TestimonialDto
                {
                    Testimonial = testimonial,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TestimonialDto>(ResultStatus.Error, Messages.Testimonial.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int testimonialId)
        {
            var result = await UnitOfWork.Testimonials.AnyAsync(a => a.Id == testimonialId);
            if (result)
            {
                var testimonial = await UnitOfWork.Testimonials.GetAsync(a => a.Id == testimonialId);
                await UnitOfWork.Testimonials.DeleteAsync(testimonial);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Testimonial.HardDelete);
            }
            return new Result(ResultStatus.Error, Messages.Testimonial.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(TestimonialUpdateDto testimonialUpdateDto, string modifiedByName)
        {
            var oldTestimonial = await UnitOfWork.Testimonials.GetAsync(a => a.Id == testimonialUpdateDto.Id);
            var testimonial = Mapper.Map<TestimonialUpdateDto, Testimonial>(testimonialUpdateDto, oldTestimonial);
            testimonial.ModifiedByName = modifiedByName;
            await UnitOfWork.Testimonials.UpdateAsync(testimonial);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Testimonial.Update);
        }
    }
}
