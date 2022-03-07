using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_ResumeApplication.ViewModel;

namespace WPF_ResumeApplication
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WPF_ResumeApplication.MainWindow window = new MainWindow();
            MainViewModel mvm = new MainViewModel();
            window.DataContext = mvm;
            window.Show();
        }
    }
}
