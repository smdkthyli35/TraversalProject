using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TestimonialUpdateDto
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Comment { get; set; }
        public string ClientImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
