using System;
using TaxiFleetManager.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TaxiFleetManager.ViewModels;

public class TaxisListViewModel: ObservableObject
{
    private TaxiViewModel _selectedTaxi;

    public TaxiViewModel SelectedTaxi
    {
        get => _selectedTaxi;
        set => SetProperty(ref _selectedTaxi, value);
    }

    public ObservableCollection<TaxiViewModel> Taxis { get; set; }
    public TaxisListViewModel() => Taxis = [];

    public async Task RefreshItems()
    {
        IEnumerable<Models.Taxi> taxisData = await Models.TaxiDatabase.GetTaxi();

        foreach(Taxi taxi in taxisData)
        {
            Taxis.Add(new TaxiViewModel(taxi));
        }
    }

    public void DeleteTaxi(TaxiViewModel taxi)
    {
        Taxis.Remove(taxi);
    }

    public void AddTaxi(TaxiViewModel taxi)
    {
        Taxis.Add(taxi);
    }

    public async Task SaveTaxis()
    {
        await Models.TaxiDatabase.WriteTaxis(Taxis);
    }
}
