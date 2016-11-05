using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApplication.Command
{
    class DivCommand : ICommand, INotifyPropertyChanged
    {
        public string Result { get; set; }
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int[] input = (int[])parameter;
            int inputA = input[0];
            int inputB = input[1];
            if (inputB == 0)
            {
                Result = "エラー";
            }
            else
            {
                Result = (inputA / (float)inputB).ToString();
            }

            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }
    }
}
