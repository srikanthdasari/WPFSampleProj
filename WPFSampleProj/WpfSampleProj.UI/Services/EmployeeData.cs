using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSampleProj.UI.Context;
using WPFSampleProj.UI.Model;

namespace WpfSampleProj.UI.Services
{
    public class EmployeeData : IEmployeeData
    {
        public EmployeeData(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeHours> GetAllEmployeeHours()
        {
            return _context.EmployeeHoursList;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public IEnumerable<Employee> GetEmployeesByEmpNo(int empno)
        {
            return _context.Employees.Where(o=>o.EmployeeNumber==empno);
        }

        public IEnumerable<EmployeeHours> GetEmployeeHoursByEmpnonDate(int empno, DateTime paystart, DateTime payend)
        {
            var result = _context.EmployeeHoursList.ToList()
                            .Where(x => x.Employee.EmployeeNumber == empno && x.WorkDate >= paystart && x.WorkDate <= payend);
                            //.GroupBy(x =>new  { x.WorkDate, x.Employee.EmployeeNumber , x.Employee})
                            //.Select(g => new EmployeeHours
                            //{
                            //    EmployeeNumber=  g.Key.EmployeeNumber, Employee=g.Key.Employee, WorkDate=g.Key.WorkDate, HoursWorked = g.Sum(l => l.HoursWorked), Description = string.Join(";", g.Select(i => i.Description))
                            //});

            return result;

        }

        public EmployeeHours GetEmployeeHoursByEmpnonDate(int empno, DateTime workdate)
        {
            return _context.EmployeeHoursList.Where(x => x.Employee.EmployeeNumber == empno && x.WorkDate == workdate).FirstOrDefault();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Add(EmployeeHours empHours, Employee emp)
        {
            var empobj = _context.Employees.FirstOrDefault(x => x.EmployeeNumber == emp.EmployeeNumber);
            if (empobj != null)
            {
                empobj.EmployeeHours.Add(new EmployeeHours{
                    Description=empHours.Description,
                    HoursWorked=empHours.HoursWorked,
                    WorkDate=empHours.WorkDate
                });
                _context.SaveChanges();
            }            
        }

        private EmployeeContext _context;
    }
}
