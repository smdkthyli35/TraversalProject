using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AboutPost : EntityBase, IEntity
    {
        public string FirstTitle { get; set; }
        public string SecondTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
