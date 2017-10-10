using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSampleProj.UI.Model;

namespace WpfSampleProj.UI.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAllEmployees();

        IEnumerable<EmployeeHours> GetAllEmployeeHours();

        IEnumerable<Employee> GetEmployeesByEmpNo(int empno);

        IEnumerable<EmployeeHours> GetEmployeeHoursByEmpnonDate(int empno, DateTime paystart, DateTime payend);

        EmployeeHours GetEmployeeHoursByEmpnonDate(int empno, DateTime workdate);
        void Commit();

        void Add(EmployeeHours empHours, Employee emp);

    }
}
