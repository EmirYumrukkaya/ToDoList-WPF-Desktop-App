using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoList.Commands;
using ToDoList.Model;


namespace ToDoList.ViewModel
{
    public class AddTaskViewModel
    {
        public string? name {  get; set; }
        public DateTime? date { get; set; }
        public string? priority { get; set; }

        public List<string> PriorityOptions { get; set; } = new List<string>
        {
            "Critical",
            "High",
            "Medium",
            "Low"
        };

        public ICommand AddTaskButtonCommand { get; set; }

        public AddTaskViewModel() {
            AddTaskButtonCommand = new RelayCommand(AddTaskButton, CanAddTask);
        }

        public bool CanAddTask(object obj)
        {
            return true;
        }

        public void AddTaskButton(object obj)
        {
           
            if (string.IsNullOrWhiteSpace(name) || date == null || string.IsNullOrWhiteSpace(priority))
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }


            Model.Task newtask = new Model.Task()
                {
                    Name = name,
                    DueDate = date,
                    Priority = priority

                };
                Model.TaskManager.AddTask(newtask);

           
            MessageBox.Show($"Task added: {newtask.Name}");
            

        }
    }
}
