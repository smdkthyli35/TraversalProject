﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AboutAddDto
    {
        public string FirstTitle { get; set; }
        public string FirstDescription { get; set; }
        public string FirstImage { get; set; }
        public string SecondTitle { get; set; }
        public string SecondDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
