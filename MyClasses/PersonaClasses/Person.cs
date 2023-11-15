using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyClasses;
public class Person
{
    public Person()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}