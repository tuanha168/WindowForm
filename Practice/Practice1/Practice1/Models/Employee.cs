using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Models
{
    class Employee
    {
        public string Name { get; set; }
        public string Roles { get; set; }
        public string BirthYear { get; set; }
        public Employee()
        {
            //empty constructor  
        }
        public Employee(string name, string roles, string birthyear)
        {
            Name = name;
            Roles = roles;
            BirthYear = birthyear;
        }
    }
}
