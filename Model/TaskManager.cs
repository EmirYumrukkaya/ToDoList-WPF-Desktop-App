using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.ViewModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ToDoList.Model
{
    public class TaskManager
    {
        
        private readonly static string filePath="Tasks.json";

        public static ObservableCollection<Model.Task> DataTasks= TaskManager.LoadTasks() ;

        public static void AddTask(Model.Task task)
        {
            DataTasks.Add(task);
            
        }

        public static void SaveTasks()
        {
            try
            {
                string jsonTasks = JsonSerializer.Serialize(DataTasks, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonTasks);
            }
            catch (Exception ex) { Console.WriteLine($"Save to file error:{ex.Message}"); }

        }
        
        public static ObservableCollection<Model.Task> LoadTasks()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "[]");
                }
                string jsonTask = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<ObservableCollection<Model.Task>>(jsonTask)?? new ObservableCollection<Model.Task>();
            }
            catch (Exception ex) { Console.WriteLine($"Load from file error:{ex.Message}"); }

            return new ObservableCollection<Model.Task>();
        }

        /*public static ObservableCollection<Model.Task> ReturnTaskList()
        {
            return DataTasks;
        }*/

    }
}

