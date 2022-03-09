using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDestinationService
    {
        Task<IDataResult<DestinationDto>> GetAsync(int destinationId);
        Task<IDataResult<DestinationListDto>> GetAllAsync();
        Task<IDataResult<DestinationListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<DestinationListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(DestinationAddDto destinationAddDto, string createdByName);
        Task<IResult> UpdateAsync(DestinationUpdateDto destinationUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int destinationId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int destinationId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
