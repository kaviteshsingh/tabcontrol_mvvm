using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using TabbedLayout.Commands;
using TabbedLayout.Model;


namespace TabbedLayout.ViewModels
{
    class TabOneViewModel : WorkspaceViewModel
    {
        private Person _CurrentUser;

        public Person CurrentUser
        {
            get { return _CurrentUser; }
            set { _CurrentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        private DelegateCommand _cmdSubmit;

        public DelegateCommand CmdSubmit
        {
            get { return _cmdSubmit ?? (_cmdSubmit = new DelegateCommand(SubmitHandler)); }
        }

        private void SubmitHandler()
        {
            Console.WriteLine(CurrentUser.ToString());
        }



        public TabOneViewModel()
        {
            CurrentUser = new Person();
            CurrentUser.Name = DateTime.Now.ToString();
        }


    }
}