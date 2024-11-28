namespace TaxiFleetManager.Views;

public partial class TaxiDetailPage : ContentPage
{
	public TaxiDetailPage()
	{
		InitializeComponent();
		BindingContext = App.MainViewModel.SelectedTaxi;
	}
}