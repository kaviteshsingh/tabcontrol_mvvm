using System.Windows;
using MvvmStarter.Views;
using TabbedLayout.ViewModels;

namespace TabbedLayout
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void OnStartup(object sender, StartupEventArgs e)
		{
            // Create the ViewModel and expose it using the View's DataContext
            MainView view = new MainView();
            //view.DataContext = new MainViewModel();
            view.Show();
        }
	}
}


