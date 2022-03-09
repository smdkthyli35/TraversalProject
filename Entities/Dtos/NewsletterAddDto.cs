using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NewsletterAddDto
    {
        public string Mail { get; set; }
        public bool IsActive { get; set; }
    }
}
