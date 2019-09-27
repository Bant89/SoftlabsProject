using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string _PageName;
        public string PageName
        {
            get { return _PageName; }
            set { SetProperty(ref _PageName, value); }
        }


    }
}
