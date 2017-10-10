using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSampleProj.UI.Model
{
    public class EmployeeHours
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime WorkDate { get; set; }

        [MaxLength(80)]
        public string Description { get; set; }

        [Range(1, 600)]
        public int HoursWorked { get; set; }


        public int EmployeeRefId { get; set; }
        [ForeignKey("EmployeeRefId")]
        public virtual Employee Employee { get; set; }
    }
}
