using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfDestinationDal : EfEntityRepositoryBase<Destination>, IDestinationDal
    {
        public EfDestinationDal(DbContext context) : base(context)
        {
        }
    }
}
