using TaxiFleetManager.ViewModels;

namespace TaxiFleetManager.Views;

public partial class AddTaxiPage : ContentPage
{
	string enteredId;
	string enteredMake;
	string enteredModel;
	string enteredElectric;
	public AddTaxiPage()
	{
		InitializeComponent();
	}

	private void Entry_IdChanged(object sender, TextChangedEventArgs e)
	{
		enteredId = ((Entry)sender).Text;
	}

	private void Entry_MakeChanged(object sender, TextChangedEventArgs e)
	{
		enteredMake = ((Entry)sender).Text;
	}

	private void Entry_ModelChanged(object sender, TextChangedEventArgs e)
	{
		enteredModel = ((Entry)sender).Text;
	}

	private void Entry_ElectricChanged(object sender, TextChangedEventArgs e)
	{
		enteredElectric = ((Entry)sender).Text;
	}

	private void Entry_IdCompleted(object sender, EventArgs e)
	{
		enteredId = ((Entry)sender).Text;
	}

	private void Entry_MakeCompleted(object sender, EventArgs e)
	{
		enteredMake = ((Entry)sender).Text;
	}	

	private void Entry_ModelCompleted(object sender, EventArgs e)
	{
		enteredModel = ((Entry)sender).Text;
	}

	private void Entry_ElectricCompleted(object sender, EventArgs e)
	{
		enteredElectric = ((Entry)sender).Text;
	}

	private async void  Button_AddTaxiClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(enteredId) || string.IsNullOrEmpty(enteredMake) || string.IsNullOrEmpty(enteredModel) || string.IsNullOrEmpty(enteredElectric))
		{
			await DisplayAlert("Error", "Please fill in all fields", "OK");
		}
		else
		{
			Models.Taxi newTaxi = new(enteredId, enteredMake, enteredModel, enteredElectric, "taxi_fleet_logo.png");
			App.MainViewModel.AddTaxi(new ViewModels.TaxiViewModel(newTaxi));
			await DisplayAlert("Success", "Taxi added", "OK");
			await Navigation.PopAsync();
		}
	}
}