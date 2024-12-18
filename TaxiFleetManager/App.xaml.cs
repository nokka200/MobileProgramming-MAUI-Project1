﻿namespace TaxiFleetManager;

public partial class App : Application
{
	public static ViewModels.TaxisListViewModel MainViewModel { get; private set; }
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		MainViewModel = new();
		InitializeAsync();

		UserAppTheme = AppTheme.Dark;
	}

	private async void InitializeAsync()
	{
		await MainViewModel.RefreshItems();
	}
}
