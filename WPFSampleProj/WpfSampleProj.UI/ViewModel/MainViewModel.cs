using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfSampleProj.UI.Extensions;
using WpfSampleProj.UI.Services;
using WpfSampleProj.UI.Utils;
using WPFSampleProj.UI.Model;

namespace WpfSampleProj.UI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region Injected
        private IEmployeeData EmployeeData { get; set; }
        private TaskManager TaskManager { get; set; }
        #endregion


        #region Private Fields

        private Employee _currentemployee;
        private List<EmployeeHours> _employeeHours;
        private List<Employee> _employees;
        private string _payStartDate;
        private string _payEndDate;
        private int _currentEmployeeIndex = 0;
        private int _totalHours = 0;
        #endregion


        #region Notify Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion

        #region public Properties

        public List<EmployeeHours> EmployeeHours
        {
            get { return _employeeHours; }
            set
            {
                _employeeHours = value;
                NotifyPropertyChanged("EmployeeHours");
                TotalHours = _employeeHours.Sum(x => x.HoursWorked);
                NotifyPropertyChanged("TotalHours");
            }
        }

        public List<Employee> AllEmployees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                NotifyPropertyChanged("AllEmployees");
            }
        }

        public Employee CurrentEmployee
        {
            get { return _currentemployee; }
            set
            {
                _currentemployee = value;
                NotifyPropertyChanged("CurrentEmployee");
            }

        }


        public String PayStartDate
        {
            get { return _payStartDate; }
            set
            {
                _payStartDate = value;
                NotifyPropertyChanged("PayStartDate");
            }
        }


        public String PayEndDate
        {
            get { return _payEndDate; }
            set
            {
                _payEndDate = value;
                NotifyPropertyChanged("PayEndDate");
            }
        }


        public int TotalHours
        {
            get { return _totalHours; }
            set
            {
                _totalHours = value;
                NotifyPropertyChanged("TotalHours");
            }

        }

        #endregion


        #region Commands
        private ICommand nextCommand;
        private ICommand prevousCommand;
        private ICommand applyCommand;
        private ICommand textChangeCommand;
        public ICommand NextCommand { get{ return nextCommand ?? (nextCommand = new RelayCommand(OnNextCommand)); } }
        public ICommand PreviousCommand { get { return prevousCommand ??(prevousCommand= new RelayCommand(OnPreviousCommand)); } }
        public ICommand ApplyCommand { get { return applyCommand ?? (applyCommand = new RelayCommand(OnApplyCommand)); } }
        public ICommand TextChangeCommand { get { return textChangeCommand ?? (textChangeCommand = new RelayCommand(OnTextChangeCommand)); } }


        #endregion

        public MainViewModel(IEmployeeData _employeeData, TaskManager taskManager)
        {
            EmployeeData = _employeeData;
            TaskManager = taskManager;

            PayStartDate = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).ToShortDateString();
            PayEndDate = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).AddDays(13).ToShortDateString();

            TaskManager.RunInBackground(() =>
            {
                AllEmployees = EmployeeData.GetAllEmployees().OrderBy(x => x.EmployeeNumber).ToList();
                BuildUI();
            });
        }


        #region Public Methods
        private void OnNextCommand(object obj)
        {
            TaskManager.RunInBackground(() =>
            {
                _currentEmployeeIndex++;
                if (AllEmployees.Count() <= _currentEmployeeIndex) _currentEmployeeIndex = 0;


                BuildUI();


            });
        }

        private void OnPreviousCommand(object obj)
        {
            TaskManager.RunInBackground(() =>
            {
                _currentEmployeeIndex--;
                if(_currentEmployeeIndex<0) _currentEmployeeIndex = AllEmployees.Count();


                BuildUI();
            });
        }


        private void BuildUI()
        {
            if (AllEmployees.Count() > _currentEmployeeIndex)
            {
                var Empobj = AllEmployees.Skip(_currentEmployeeIndex).FirstOrDefault();
                if (Empobj != null)
                {
                    CurrentEmployee = Empobj;


                    List<EmployeeHours> _list = new List<EmployeeHours>();

                    for (var i = Convert.ToDateTime(PayStartDate); i <= Convert.ToDateTime(PayEndDate); i=i.AddDays(1))
                    {
                        _list.Add(new EmployeeHours
                        {
                            WorkDate = i,
                            
                            Employee =new Employee { EmployeeNumber=CurrentEmployee.EmployeeNumber, EmployeeFirstName=CurrentEmployee.EmployeeFirstName , EmployeeLastName=CurrentEmployee.EmployeeLastName, HireDate=CurrentEmployee.HireDate},
                            HoursWorked=0,
                            Description=String.Empty
                        });
                    }

                    
                    var db = EmployeeData.GetEmployeeHoursByEmpnonDate(CurrentEmployee.EmployeeNumber, Convert.ToDateTime(PayStartDate), Convert.ToDateTime(PayEndDate));
                    EmployeeHours = (from l in _list
                                        join d in db on l.WorkDate equals d.WorkDate into temp
                                        from d in temp.DefaultIfEmpty()
                                        select new EmployeeHours
                                        {
                                            WorkDate=l.WorkDate,
                                            Employee=l.Employee,
                                            Id=d==null?0:d.Id,
                                            Description=d==null?String.Empty:d.Description,
                                            HoursWorked=d==null?0 : d.HoursWorked
                                        }).ToList();
                }
            }
        }



        private void OnApplyCommand(object obj)
        {
            if(EmployeeHours!=null)
            {
                foreach(EmployeeHours e in EmployeeHours)
                {
                    e.EmployeeRefId = e.Employee.EmployeeNumber;
                    //check if that record exist..if yes Update.
                    if (EmployeeData.GetEmployeeHoursByEmpnonDate(e.Employee.EmployeeNumber, e.WorkDate) != null)
                    {
                        EmployeeData.GetEmployeeHoursByEmpnonDate(e.Employee.EmployeeNumber, e.WorkDate).Description = e.Description;
                        EmployeeData.GetEmployeeHoursByEmpnonDate(e.Employee.EmployeeNumber, e.WorkDate).HoursWorked = e.HoursWorked;
                        EmployeeData.Commit();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(e.Description) || e.HoursWorked > 0)
                        {
                            
                            EmployeeData.Add(e,CurrentEmployee);

                        } 
                    }
                    //Check if that record not exist ...simply add..
                }
            }
        }


        private void OnTextChangeCommand(object obj)
        {
            if (EmployeeHours != null)
            {
                TotalHours = EmployeeHours.Sum(x => x.HoursWorked);
            }
        }

        #endregion
    }
}
