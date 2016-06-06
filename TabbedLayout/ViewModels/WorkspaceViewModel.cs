using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TabbedLayout.Commands;

namespace TabbedLayout.ViewModels
{
	public abstract class WorkspaceViewModel : ViewModelBase
	{
		private string _header;
		public string Header
		{
			get { return _header; }
			set
			{
				_header = value;
				OnPropertyChanged("Header");
			}
		}

		private DelegateCommand _closeCommand;
		public ICommand CloseCommand
		{
			get { return _closeCommand ?? (_closeCommand = new DelegateCommand(OnRequestClose));}
		}

		public event EventHandler RequestClose;
		private void OnRequestClose()
		{
			if (RequestClose != null)
				RequestClose(this, EventArgs.Empty);
		}
	}
}
