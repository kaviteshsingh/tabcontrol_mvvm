using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using TabbedLayout.Commands;

namespace TabbedLayout.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructor

        public MainViewModel()
        {
            Workspaces = new ObservableCollection<WorkspaceViewModel>();
            Workspaces.CollectionChanged += Workspaces_CollectionChanged;
        }

        #endregion

        #region Event Handlers

        void Workspaces_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null && e.NewItems.Count != 0)
                foreach(WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if(e.OldItems != null && e.OldItems.Count != 0)
                foreach(WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            CloseWorkspace();
        }

        #endregion

        #region Commands

        private DelegateCommand _exitCommand;
        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new DelegateCommand(() => Application.Current.Shutdown())); }
        }

        private DelegateCommand _newWorkspaceCommand;
        public ICommand NewWorkspaceCommand
        {
            get { return _newWorkspaceCommand ?? (_newWorkspaceCommand = new DelegateCommand(NewWorkspace)); }
        }

        private DelegateCommand _newTabOneCommand;
        public ICommand NewTabOneCommand
        {
            get { return _newTabOneCommand ?? (_newTabOneCommand = new DelegateCommand(NewTabOne)); }
        }

        private DelegateCommand _newTabTwoCommand;
        public ICommand NewTabTwoCommand
        {
            get { return _newTabTwoCommand ?? (_newTabTwoCommand = new DelegateCommand(NewTabTwo)); }
        }

        private void NewTabOne()
        {
            var workspace = new TabOneViewModel { Header = "NewTab One" };
            Workspaces.Add(workspace);
            SelectedIndex = Workspaces.IndexOf(workspace);
        }

        private void NewTabTwo()
        {
            var workspace = new TabTwoViewModel { Header = "NewTab Two" };
            Workspaces.Add(workspace);
            SelectedIndex = Workspaces.IndexOf(workspace);
        }

        private void NewWorkspace()
        {
            var workspace = new WorkspaceViewModel { Header = "New Workspace" };
            Workspaces.Add(workspace);
            SelectedIndex = Workspaces.IndexOf(workspace);
        }

        private DelegateCommand _closeWorkspaceCommand;
        public ICommand CloseWorkspaceCommand
        {
            get { return _closeWorkspaceCommand ?? (_closeWorkspaceCommand = new DelegateCommand(CloseWorkspace, () => Workspaces.Count > 0)); }
        }

        private void CloseWorkspace()
        {
            Workspaces.RemoveAt(SelectedIndex);
            SelectedIndex = 0;
        }

        #endregion

        #region Public Members

        public ObservableCollection<WorkspaceViewModel> Workspaces { get; set; }

        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        #endregion
    }
}


