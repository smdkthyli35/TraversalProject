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
    public class DestinationManager : ManagerBase, IDestinationService
    {
        public DestinationManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(DestinationAddDto destinationAddDto, string createdByName)
        {
            var destination = Mapper.Map<Destination>(destinationAddDto);
            destination.CreatedByName = createdByName;
            destination.ModifiedByName = createdByName;
            await UnitOfWork.Destinations.AddAsync(destination);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Destination.Add);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var destinationsCount = await UnitOfWork.Destinations.CountAsync();
            if (destinationsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, destinationsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var destinationsCount = await UnitOfWork.Destinations.CountAsync(d => !d.IsDeleted);
            if (destinationsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, destinationsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int destinationId, string modifiedByName)
        {
            var result = await UnitOfWork.Destinations.AnyAsync(a => a.Id == destinationId);
            if (result)
            {
                var destination = await UnitOfWork.Destinations.GetAsync(a => a.Id == destinationId);
                destination.IsDeleted = true;
                destination.ModifiedByName = modifiedByName;
                destination.ModifiedDate = DateTime.Now;
                await UnitOfWork.Destinations.UpdateAsync(destination);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Destination.Delete);
            }
            return new Result(ResultStatus.Error, Messages.Destination.NotFound(isPlural: false));
        }

        public async Task<IDataResult<DestinationListDto>> GetAllAsync()
        {
            var destinations = await UnitOfWork.Destinations.GetAllAsync();
            if (destinations.Count > -1)
            {
                return new DataResult<DestinationListDto>(ResultStatus.Success, new DestinationListDto
                {
                    Destinations = destinations,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DestinationListDto>(ResultStatus.Error, Messages.Destination.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<DestinationListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var destinations = await UnitOfWork.Destinations.GetAllAsync(d => !d.IsDeleted && d.IsActive);
            if (destinations.Count > -1)
            {
                return new DataResult<DestinationListDto>(ResultStatus.Success, new DestinationListDto
                {
                    Destinations = destinations,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DestinationListDto>(ResultStatus.Error, Messages.Destination.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<DestinationListDto>> GetAllByNonDeletedAsync()
        {
            var destinations = await UnitOfWork.Destinations.GetAllAsync(d => !d.IsDeleted);
            if (destinations.Count > -1)
            {
                return new DataResult<DestinationListDto>(ResultStatus.Success, new DestinationListDto
                {
                    Destinations = destinations,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DestinationListDto>(ResultStatus.Error, Messages.Destination.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<DestinationDto>> GetAsync(int destinationId)
        {
            var destination = await UnitOfWork.Destinations.GetAsync(a => a.Id == destinationId);
            if (destination != null)
            {
                return new DataResult<DestinationDto>(ResultStatus.Success, new DestinationDto
                {
                    Destination = destination,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<DestinationDto>(ResultStatus.Error, Messages.Destination.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int destinationId)
        {
            var result = await UnitOfWork.Destinations.AnyAsync(a => a.Id == destinationId);
            if (result)
            {
                var destination = await UnitOfWork.Destinations.GetAsync(a => a.Id == destinationId);
                await UnitOfWork.Destinations.DeleteAsync(destination);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Destination.HardDelete);
            }
            return new Result(ResultStatus.Error, Messages.Destination.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(DestinationUpdateDto destinationUpdateDto, string modifiedByName)
        {
            var oldDestination = await UnitOfWork.Destinations.GetAsync(a => a.Id == destinationUpdateDto.Id);
            var destination = Mapper.Map<DestinationUpdateDto, Destination>(destinationUpdateDto, oldDestination);
            destination.ModifiedByName = modifiedByName;
            await UnitOfWork.Destinations.UpdateAsync(destination);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Destination.Update);
        }
    }
}
