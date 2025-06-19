using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Commands;
using ToDoList.Views;
using ToDoList.Model;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics;

namespace ToDoList.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {

        public List<string> MarkTask { get; set; } = new List<string>
        {
            "OnGoing",
            "StandBy",
            "Done"
        };



        private bool _isAscendingName = true;
        private string _sortHeaderText = "TaskName"; 
        public string SortHeaderText
        {
            get => _sortHeaderText;
            set
            {
                _sortHeaderText = value;
                OnPropertyChanged(nameof(SortHeaderText));
            }
        }

        private bool _isAscendingDate = true;
        private string _sortDateText = "DueDate";
        public string SortDateText
        {
            get => _sortDateText;
            set
            {
                _sortDateText = value;
                OnPropertyChanged(nameof(SortDateText));
            }
        }

        private bool _isAscendingPriority = true;
        private string _sortPriorityText = "Priority";
        public string SortPriorityText
        {
            get => _sortPriorityText;
            set
            {
                _sortPriorityText = value;
                OnPropertyChanged(nameof(SortPriorityText));
            }
        }

        public static Model.Task ChangingTask; //SelectedTask to edit
        
        private ObservableCollection<Model.Task> _mainViewTasks;
        public ObservableCollection<Model.Task> MainViewTasks
        {
            get { return _mainViewTasks; }
            set
            {
                _mainViewTasks = value;
                OnPropertyChanged(nameof(MainViewTasks));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ShowAddWindow { get; set; }

        public ICommand DeleteTaskCommand { get; set; }

        public ICommand EditScreenCommand { get; set; }

        public ICommand SortByNameCommand { get; set; }

        public ICommand SortByDateCommand { get; set; }

        public ICommand SortByPriorityCommand { get; set; }
        public MainViewModel() {
            ShowAddWindow= new RelayCommand(AddWindow, CanAddWindow);
        

            MainViewTasks=Model.TaskManager.DataTasks;

            DeleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask);

            EditScreenCommand = new RelayCommand(OpenEditScreen, CanOpenEditScreen);

            SortByNameCommand = new RelayCommand(SortName,CanSortName);

            SortByDateCommand = new RelayCommand(SortDate, CanSortDate);

            SortByPriorityCommand = new RelayCommand(SortPriority, CanSortPriority);
        }

        private void SortDate(object obj)
        {
            ObservableCollection<Model.Task> SortedList;

            if (_isAscendingDate)
            {
                SortedList = new ObservableCollection<Model.Task>(TaskManager.DataTasks.OrderBy(t => t.DueDate));
                TaskManager.DataTasks.Clear();
                foreach (Model.Task task in SortedList)
                {
                    TaskManager.DataTasks.Add(task);
                }
                SortDateText = "DueDate🔼";
            }
            else
            {
                SortedList = new ObservableCollection<Model.Task>(TaskManager.DataTasks.OrderByDescending(t => t.DueDate));
                TaskManager.DataTasks.Clear();
                foreach (Model.Task task in SortedList)
                {
                    TaskManager.DataTasks.Add(task);
                }
                SortDateText = "DueDate🔽";
            }
            _isAscendingDate = !_isAscendingDate;
            SortHeaderText = "TaskName";
            SortPriorityText = "Priority";
        }

        private bool CanSortDate(object obj)
        {
            return true;
        }

        private void SortPriority(object obj)
        {
            ObservableCollection<Model.Task> SortedList;

            if (_isAscendingPriority)
            {
                SortedList = new ObservableCollection<Model.Task>(TaskManager.DataTasks.OrderBy(t => GetPriorityValue(t.Priority)));
                TaskManager.DataTasks.Clear();
                foreach (Model.Task task in SortedList)
                {
                    TaskManager.DataTasks.Add(task);
                }
                SortPriorityText = "Priority🔼";
            }
            else
            {
                SortedList = new ObservableCollection<Model.Task>(TaskManager.DataTasks.OrderByDescending(t => GetPriorityValue(t.Priority)));
                TaskManager.DataTasks.Clear();
                foreach (Model.Task task in SortedList)
                {
                    TaskManager.DataTasks.Add(task);
                }
                SortPriorityText = "Priority🔽";
            }
            _isAscendingPriority = !_isAscendingPriority;
            SortDateText = "DueDate";
            SortHeaderText = "TaskName";
        }

        private int GetPriorityValue(string priority)
        {
            return priority switch
            {
                "Critical" => 4,
                "High" => 3,
                "Medium" => 2,
                "Low" => 1,
                _ => 0 
            };
        }
        private bool CanSortPriority(object obj)
        {
            return true;
        }

        private void SortName(object obj)
        {
            ObservableCollection<Model.Task> SortedList;

            if (_isAscendingName)
            {
                SortedList = new ObservableCollection<Model.Task>(TaskManager.DataTasks.OrderBy(t => t.Name.Length));
                TaskManager.DataTasks.Clear();
                foreach (Model.Task task in SortedList)
                {
                    TaskManager.DataTasks.Add(task);
                }
                SortHeaderText = "TaskName🔼";
            }
            else
            {
                SortedList = new ObservableCollection<Model.Task>(TaskManager.DataTasks.OrderByDescending(t => t.Name.Length));
                TaskManager.DataTasks.Clear();
                foreach (Model.Task task in SortedList)
                {
                    TaskManager.DataTasks.Add(task);
                }
                SortHeaderText = "TaskName🔽";
            }
            _isAscendingName = !_isAscendingName;
            SortDateText = "DueDate";
            SortPriorityText = "Priority";
        }

        private bool CanSortName(object obj)
        {
            return true;
        }

        private void OpenEditScreen(object obj)
        {
            ChangingTask =(Model.Task)obj;
            EditTaskScreen editscrn = new EditTaskScreen();
            editscrn.Show();
        }

        private bool CanOpenEditScreen(object obj)
        {
            return true;
        }

        private static bool CanAddWindow(object obj)
        {
            return true;
        }

        private static void AddWindow(object obj)
        {
           AddTaskScreen showscreen= new AddTaskScreen() ;
            showscreen.Show();
        }

        private bool CanDeleteTask(object obj)
        {
            return true;
        }

        private void DeleteTask(object obj)
        {
            
            Model.Task taskToRemove=(Model.Task)obj;
            if (taskToRemove is Model.Task)
            {
                int index = MainViewTasks.IndexOf(taskToRemove);
                if (index >= 0)
                {
                    TaskManager.DataTasks.RemoveAt(index);
                    MessageBox.Show($"Deleted: {taskToRemove.Name}");
                }
            }
        }


    }
}
