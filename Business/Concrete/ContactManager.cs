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
    public class ContactManager : ManagerBase, IContactService
    {
        public ContactManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IResult> AddAsync(ContactAddDto contactAddDto, string createdByName)
        {
            var contact = Mapper.Map<Contact>(contactAddDto);
            contact.CreatedByName = createdByName;
            contact.ModifiedByName = createdByName;
            await UnitOfWork.Contacts.AddAsync(contact);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Contact.Add);
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var contactsCount = await UnitOfWork.Contacts.CountAsync();
            if (contactsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, contactsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var contactsCount = await UnitOfWork.Contacts.CountAsync(c => !c.IsDeleted);
            if (contactsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, contactsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int contactId, string modifiedByName)
        {
            var result = await UnitOfWork.Contacts.AnyAsync(a => a.Id == contactId);
            if (result)
            {
                var contact = await UnitOfWork.Contacts.GetAsync(a => a.Id == contactId);
                contact.IsDeleted = true;
                contact.ModifiedByName = modifiedByName;
                contact.ModifiedDate = DateTime.Now;
                await UnitOfWork.Contacts.UpdateAsync(contact);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Contact.Delete);
            }
            return new Result(ResultStatus.Error, Messages.Contact.NotFound(isPlural: false));
        }

        public async Task<IDataResult<ContactListDto>> GetAllAsync()
        {
            var contacts = await UnitOfWork.Contacts.GetAllAsync();
            if (contacts.Count > -1)
            {
                return new DataResult<ContactListDto>(ResultStatus.Success, new ContactListDto
                {
                    Contacts = contacts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactListDto>(ResultStatus.Error, Messages.Contact.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ContactListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var contacts = await UnitOfWork.Contacts.GetAllAsync(c => !c.IsDeleted && c.IsActive);
            if (contacts.Count > -1)
            {
                return new DataResult<ContactListDto>(ResultStatus.Success, new ContactListDto
                {
                    Contacts = contacts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactListDto>(ResultStatus.Error, Messages.Contact.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ContactListDto>> GetAllByNonDeletedAsync()
        {
            var contacts = await UnitOfWork.Contacts.GetAllAsync(c => !c.IsDeleted);
            if (contacts.Count > -1)
            {
                return new DataResult<ContactListDto>(ResultStatus.Success, new ContactListDto
                {
                    Contacts = contacts,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactListDto>(ResultStatus.Error, Messages.Contact.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ContactDto>> GetAsync(int contactId)
        {
            var contact = await UnitOfWork.Contacts.GetAsync(a => a.Id == contactId);
            if (contact != null)
            {
                return new DataResult<ContactDto>(ResultStatus.Success, new ContactDto
                {
                    Contact = contact,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ContactDto>(ResultStatus.Error, Messages.Contact.NotFound(isPlural: false), null);
        }

        public async Task<IResult> HardDeleteAsync(int contactId)
        {
            var result = await UnitOfWork.Contacts.AnyAsync(a => a.Id == contactId);
            if (result)
            {
                var contact = await UnitOfWork.Contacts.GetAsync(a => a.Id == contactId);
                await UnitOfWork.Contacts.DeleteAsync(contact);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Contact.HardDelete);
            }
            return new Result(ResultStatus.Error, Messages.Contact.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(ContactUpdateDto contactUpdateDto, string modifiedByName)
        {
            var oldContact = await UnitOfWork.Contacts.GetAsync(a => a.Id == contactUpdateDto.Id);
            var contact = Mapper.Map<ContactUpdateDto, Contact>(contactUpdateDto, oldContact);
            contact.ModifiedByName = modifiedByName;
            await UnitOfWork.Contacts.UpdateAsync(contact);
            await UnitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, Messages.Contact.Update);
        }
    }
}
