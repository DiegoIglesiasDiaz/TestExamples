﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses;
public class Supervisor : Person
{
    public Supervisor()
    {
        Employees = new();
    }
    public List<Employee> Employees { get; set; }
}
