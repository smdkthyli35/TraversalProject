﻿using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TestimonialDto : DtoGetBase
    {
        public Testimonial Testimonial { get; set; }
    }
}
