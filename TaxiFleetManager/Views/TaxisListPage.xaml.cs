namespace TaxiFleetManager.Views;

public partial class TaxisListPage : ContentPage
{
	public TaxisListPage()
	{
		InitializeComponent();
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		await Navigation.PushAsync(new TaxiDetailPage());
	}

	private void MenuItem_Clicked(object sender, EventArgs e)
	{
		MenuItem manuItem = (MenuItem)sender;
		ViewModels.TaxiViewModel taxi = (ViewModels.TaxiViewModel)manuItem.BindingContext;
		App.MainViewModel.DeleteTaxi(taxi);
	}

	private async void Save_Clicked(object sender, EventArgs e)
	{
		await App.MainViewModel.SaveTaxis();
	}
}