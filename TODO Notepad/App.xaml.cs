using System.Windows;
using System.Windows.Threading;

namespace TODO_Notepad
{
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Exception: " + e.Exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
