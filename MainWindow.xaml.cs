using MahApps.Metro.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace ToggleSwitchIsCheckedBindingLoss
{
	public partial class MainWindow : Window
	{
		public MainWindow() => InitializeComponent();

		void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
		{
			var binding = new Binding(nameof(MainWindowViewModel.P2)) { Mode = BindingMode.OneWay };
			((ToggleSwitch)sender).SetBinding(ToggleSwitch.IsCheckedProperty, binding);
		}
	}
}
