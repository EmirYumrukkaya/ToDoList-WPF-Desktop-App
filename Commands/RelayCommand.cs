using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoList.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public Action<object> WhatExecute;

        public Predicate<object> WhatCanExecute;


        public RelayCommand(Action<object> whatExecuteMethod, Predicate<object> whatCanExecuteMethod)
        {
            WhatExecute = whatExecuteMethod;
            WhatCanExecute = whatCanExecuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
           return WhatCanExecute(parameter);
        }
        
        public void Execute(object? parameter)
        {
           WhatExecute(parameter);
        }
    }
}
