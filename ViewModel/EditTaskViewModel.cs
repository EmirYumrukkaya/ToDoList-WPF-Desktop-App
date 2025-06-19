using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ToDoList.Commands;
using ToDoList.Model;


namespace ToDoList.ViewModel
{
    public class EditTaskViewModel
    {
        public Model.Task Selectedtask;
        public string? name { get; set; }
        public DateTime? date { get; set; }
        public string? priority { get; set; }

        public List<string> PriorityOptions { get; set; } = new List<string>
        {
            "Critical",
            "High",
            "Medium",
            "Low"
        };

        public ICommand EditTaskButtonCommand { get; set; }

        public EditTaskViewModel()
        {
            EditTaskButtonCommand = new RelayCommand(EditTaskButton, CanEditTask);
            Selectedtask=MainViewModel.ChangingTask;
            if (Selectedtask != null)
            {
                name = Selectedtask.Name;
                priority = Selectedtask.Priority;
                date = Selectedtask.DueDate;
            }
        }

        public bool CanEditTask(object obj)
        {
            return true;
        }

        public void EditTaskButton(object obj)
        {

            MessageBox.Show("Edited");

            Model.Task newtask = new Model.Task()
            {
                Name = name,
                DueDate = date,
                Priority = priority

            };

            
            if (Selectedtask is Model.Task)
            {
                int index = TaskManager.DataTasks.IndexOf(Selectedtask);
                if (index >= 0)
                {
                    TaskManager.DataTasks.RemoveAt(index);
                    TaskManager.DataTasks.Insert(index,newtask);
                }
            }


        }
    }
}
