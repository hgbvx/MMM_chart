﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MMM_chart.ViewModel
{ 
    public class ButtonCommand : ICommand
    {
        private readonly Action handler;
        private bool isEnabled;

        public ButtonCommand(Action handler)
        {
            // Assign the method name to the handler
            this.handler = handler;

            // By default the button is enabled
            this.isEnabled = true;
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        // Helps to execute the respective method using the handler
        public void Execute(object parameter)
        {
            //calls the respective method that has been registered with the handler
            handler();
        }
    }
}
