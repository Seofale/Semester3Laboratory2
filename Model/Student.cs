﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student: IDomainObject
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Speciality { set; get; }
        public string Group { set; get; }
    }
}
