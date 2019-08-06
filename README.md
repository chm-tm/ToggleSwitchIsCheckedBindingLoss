Features two ToggleSwitches and a ToggleSwitchButton.
All switches control the view model's P2 property and have their IsChecked property bound to P2.
As soon as the second ToggleSwitch is engaged, it clears its IsChecked Binding and no longer listens to changes to P2.

There is a work around by subscribing the following event handler to the Checked and Unchecked events:

```C#
void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
{
  var binding = new Binding(nameof(MainWindowViewModel.P2)) { Mode = BindingMode.OneWay };
  ((ToggleSwitch)sender).SetBinding(ToggleSwitch.IsCheckedProperty, binding);
}
```
The event handler just recreates the binding. Note that this doesn't work when subscribing to the IsCheckedChanged event.
