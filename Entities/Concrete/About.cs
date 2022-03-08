﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About : BaseEntity, IEntity
    {
        public string Details { get; set; }
        public string Image { get; set; }
    }
}
