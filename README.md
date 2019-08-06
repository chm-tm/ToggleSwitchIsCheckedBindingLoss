Features two ToggleSwitches and a ToggleSwitchButton.
All switches control the view model's P2 property and have their IsChecked property bound to P2.
As soon as the second ToggleSwitch is engaged, it clears its IsChecked Binding and no longer listens to changes to P2.
