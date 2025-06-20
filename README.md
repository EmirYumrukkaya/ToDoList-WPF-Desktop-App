# ToDo List – WPF Desktop Application (MVVM, .NET)

This is a desktop To-Do list application developed with C# and WPF, following the MVVM (Model-View-ViewModel) architectural pattern. It provides essential task management features and persistent local storage using a JSON file.

⚠️ Note:
This project focuses primarily on the MVVM structure and data handling. The UI is basic and functional, but not designed with final UX in mind.

## ✅ Features

- Add new tasks with name, due date, and priority
- Edit or delete existing tasks
- Set task status (e.g., Pending, In Progress, Completed)
- Sort tasks by **Name**, **Due Date**, or **Priority** (ascending/descending)
- Data is automatically saved to a JSON file on the user's local directory
- On restart, the application loads previously saved tasks

## 🏗️ Tech Stack

- **C#**
- **.NET (WPF)**
- **MVVM Pattern**
- **XAML**
- **JSON file-based local storage**


## 📁 Project Structure

ToDoList/

├── **Commands/**   # Custom ICommand implementations

│ └── RelayCommand.cs 

├── **Model/**  # Data layer: task structure and operations  

│ ├── Task.cs # Task properties (name, due date, priority)

│ └── TaskManager.cs # Handles task logic and JSON file operations

├── **ViewModel/**  # MVVM logic and bindings

│ ├── AddTaskViewModel.cs

│ ├── EditTaskViewModel.cs

│ └── MainViewModel.cs

├── **Views/**  # XAML UI views and their code-behinds (calls ViewModel logic)

│ ├── AddTaskScreen.xaml

│ │ └── AddTaskScreen.xaml.cs

│ ├── EditTaskScreen.xaml

│ │ └── EditTaskScreen.xaml.cs

│ ├── MainWindow.xaml

│ │ └── MainWindow.xaml.cs

├── App.xaml# Application entry point

│ └── App.xaml.cs # Application startup logic

├── AssemblyInfo.cs

└── Tasks.json # Local JSON file for persistent storage


## 🚀 Potential Future Additions

- UI/UX improvements
- Task filtering (e.g., show only pending or completed tasks)
- Task reminders or notifications
