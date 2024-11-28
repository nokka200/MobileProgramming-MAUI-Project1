namespace TaxiFleetManager;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void Handle_InspectFleet(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Views.TaxisListPage());
	}

	private async void Handle_AboutPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Views.TaxiAboutPage());
	}

	private async void Handle_AddTaxi(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Views.AddTaxiPage());
	}
}

