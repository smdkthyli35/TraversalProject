﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NewsletterUpdateDto
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
