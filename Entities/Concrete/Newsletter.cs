using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Newsletter : EntityBase, IEntity
    {
        public string Mail { get; set; }
    }
}
