using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About : EntityBase, IEntity
    {
        public string FirstTitle { get; set; }
        public string FirstDescription { get; set; }
        public string FirstImage { get; set; }
        public string SecondTitle { get; set; }
        public string SecondDescription { get; set; }
    }
}
