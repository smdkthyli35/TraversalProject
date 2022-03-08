using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Testimonial : EntityBase, IEntity
    {
        public string Client { get; set; }
        public string Comment { get; set; }
        public string ClientImage { get; set; }
    }
}
