using Caliburn.Micro;
using HallMark_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HallMark_Management_System
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
            
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
