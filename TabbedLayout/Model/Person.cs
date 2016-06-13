using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TabbedLayout.Common;

namespace TabbedLayout.Model
{
    class Person: INotifyBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value;
                OnPropertyChanged("Email");
            }
        }

        public override string ToString()
        {
            return "Name: "+ this.Name + " Email: " + this.Email;
        }

    }
}
