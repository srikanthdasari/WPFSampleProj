using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSampleProj.UI.Model
{
    public class Employee
    {
        [Key]        
        public int EmployeeNumber { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeFirstName { get; set; }

        public DateTime HireDate { get; set; }


        public virtual ICollection<EmployeeHours> EmployeeHours { get; set; }
    }
}
