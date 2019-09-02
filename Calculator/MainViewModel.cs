using System;
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
        private bool _showKeyboard;

        public MainViewModel()
        {
            Calculator = new ExpressionCalculator();
            CalculateCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = CalculateActionFunc};
            CopyCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = CopyActionFunc};
            ClearCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = ClearActionFunc};
            CloseCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = CloseActionFunc};

            //KeyboardCommands
            SquareCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"({Calculation})^2"};
            SquareRootCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"Sqrt({Calculation})"};
            PiCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}{Math.PI}"};
            FacultyCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}!"};
            OpenParenthesisCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}("};
            PowCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}^"};
            SevenCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}7"};
            FourCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}4"};
            OneCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}1"};
            CloseParenthesisCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation})"};
            SinCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"Sin({Calculation})"};
            EightCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}8"};
            FiveCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}5"};
            TwoCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}2"};
            ZeroCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}0"};
            CosCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"Cos({Calculation})"};
            NineCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}9"};
            SixCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}6"};
            ThreeCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}3"};
            PointCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}."};
            TanCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"Tan({Calculation})"};
            DivideCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}/"};
            MultiplyCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}*"};
            MinusCommand = new Command
                {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}-"};
            AddCommand = new Command {CanExecuteFunc = obj => true, ExecuteFunc = p => Calculation = $"{Calculation}+"};

            ShowKeyboard = true;
        }

        public Command CalculateCommand { get; set; }

        public Command CloseCommand { get; set; }

        public Command ClearCommand { get; set; }

        public Command CopyCommand { get; set; }

        public Command SquareCommand { get; set; }
        public Command SquareRootCommand { get; set; }
        public Command PiCommand { get; set; }
        public Command FacultyCommand { get; set; }
        public Command OpenParenthesisCommand { get; set; }
        public Command PowCommand { get; set; }
        public Command SevenCommand { get; set; }
        public Command FourCommand { get; set; }
        public Command OneCommand { get; set; }
        public Command CloseParenthesisCommand { get; set; }
        public Command SinCommand { get; set; }
        public Command EightCommand { get; set; }
        public Command FiveCommand { get; set; }
        public Command TwoCommand { get; set; }
        public Command ZeroCommand { get; set; }
        public Command CosCommand { get; set; }
        public Command NineCommand { get; set; }
        public Command SixCommand { get; set; }
        public Command ThreeCommand { get; set; }
        public Command PointCommand { get; set; }
        public Command TanCommand { get; set; }
        public Command DivideCommand { get; set; }
        public Command MultiplyCommand { get; set; }
        public Command MinusCommand { get; set; }
        public Command AddCommand { get; set; }


        public bool ShowKeyboard
        {
            get => _showKeyboard;
            set
            {
                _showKeyboard = value;
                OnPropertyChanged(nameof(ShowKeyboard));
            }
        }

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