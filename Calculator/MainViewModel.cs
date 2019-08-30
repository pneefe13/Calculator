using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CalcLib;
using Calculator.Annotations;

namespace Calculator
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _calculation;

        public MainViewModel()
        {
            Calculator = new ExpressionCalculator();
            CalculateCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = CalculateActionFunc};
            CopyCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = CopyActionFunc};
            ClearCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = ClearActionFunc};
            CloseCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = CloseActionFunc};
        }

        public Command CalculateCommand { get; set; }

        public Command CloseCommand { get; set; }
        
        public Command ClearCommand { get; set; }

        public Command CopyCommand { get; set; }

        public string Calculation
        {
            get => _calculation;
            set
            {
                _calculation = value;
                OnPropertyChanged(nameof(Calculation));
            }
        }

        private ExpressionCalculator Calculator { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void CalculateActionFunc(object parameter)
        {
            Calculate();
        }

        public void CopyActionFunc(object parameter)
        {
            Copy();
        }

        public void ClearActionFunc(object parameter)
        {
            Clear();
        }

        public void CloseActionFunc(object parameter)
        {
            Close(parameter);
        }

        public void Calculate()
        {
            Calculation = Calculator.Calculate(Calculation);
        }

        public void Close(object parameter)
        {
            ((Window) parameter).Close();
        }

        public void Copy()
        {
            Clipboard.SetText(Calculation);
        }

        public void Clear()
        {
            Calculation = string.Empty;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}