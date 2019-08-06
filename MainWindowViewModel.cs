using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ToggleSwitchIsCheckedBindingLoss
{	
	sealed class MainWindowViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public MainWindowViewModel()
		{
			SetT1 = new Command(() => {
				P1 = true;
				P2 = true; // special behavior
			});
			ClearT1 = new Command(() =>
			{
				P1 = false;
				P2 = false;
			});

			SetT2 = new Command(() => P2 = true);
			ClearT2 = new Command(() => P2 = false);
			ToggleT2 = new Command(() => P2 = !P2);
		}

		bool _p1;
		public bool P1 {
			get => _p1;
			private set {
				if (value != _p1)
				{
					_p1 = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(P1)));
				}
			}
		}
		public ICommand SetT1 { get; }
		public ICommand ClearT1 { get; }

		bool _p2;
		public bool P2 {
			get => _p2;
			private set {
				if (value != _p2)
				{
					_p2 = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(P2)));
				}
			}
		}
		public ICommand SetT2 { get; }
		public ICommand ClearT2 { get; }
		public ICommand ToggleT2 { get; }

		sealed class Command : ICommand
		{
			readonly Action _action;
			public Command(Action action) => _action = action;

			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter) => true;
			public void Execute(object parameter) => _action();
		}
	}
}
