using Prism.AppModel;
using Prism.Mvvm;
using Project.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class BaseViewModel : BindableBase //, IPageLifecycleAware
    {
        private string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { SetProperty(ref _PageName, value); }
        }

    }
}
