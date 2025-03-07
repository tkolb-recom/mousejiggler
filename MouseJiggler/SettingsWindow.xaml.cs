﻿using System.Windows;

namespace MouseJiggler;

/// <summary>
/// Interaction logic for SettingsWindow.xaml
/// </summary>
public partial class SettingsWindow : Window
{
    public SettingsViewmodel ViewModel => (SettingsViewmodel)this.DataContext;

    public SettingsWindow()
    {
        InitializeComponent();
    }

    private void AcceptChanges(object sender, RoutedEventArgs e)
    {
        // for simplicity
        DialogResult = true;
        Close();
    }
}