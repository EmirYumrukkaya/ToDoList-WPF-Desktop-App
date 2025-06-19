using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoList.ViewModel;

namespace ToDoList.Views
{
    
    public partial class AddTaskScreen : Window
    {
        public AddTaskScreen()
        {
            InitializeComponent();
            AddTaskViewModel viewModel = new AddTaskViewModel();
            this.DataContext = viewModel;
        }

        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
