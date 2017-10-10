using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfSampleProj.UI.Services;
using WpfSampleProj.UI.Utils;
using WpfSampleProj.UI.ViewModel;
using WPFSampleProj.UI.Context;

namespace WpfSampleProj.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            container.RegisterType<DbContext, EmployeeContext>();
            container.RegisterType<IEmployeeData, EmployeeData>();
            container.RegisterType<ICommand, RelayCommand>();
            container.RegisterType<TaskManager>();
            container.RegisterType<MainViewModel>();

            Application.Current.MainWindow= container.Resolve<MainWindow>();
            Application.Current.MainWindow.Show();

        }
    }
}
