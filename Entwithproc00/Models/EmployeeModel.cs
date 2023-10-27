using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entwithproc00.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public int Age { get; set; }
        public int Salary { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
    }
}