using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        Task<IDataResult<ContactDto>> GetAsync(int contactId);
        Task<IDataResult<ContactListDto>> GetAllAsync();
        Task<IDataResult<ContactListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<ContactListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(ContactAddDto contactAddDto, string createdByName);
        Task<IResult> UpdateAsync(ContactUpdateDto contactUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int contactId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int contactId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
