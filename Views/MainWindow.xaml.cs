using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.ViewModel;

namespace ToDoList.Views
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           MainViewModel mainViewModel = new MainViewModel();
           this.DataContext = mainViewModel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            Model.TaskManager.SaveTasks();
            
            base.OnClosing(e);
        }

    }
}