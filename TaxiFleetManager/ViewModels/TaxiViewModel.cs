using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TaxiFleetManager.Models;
namespace TaxiFleetManager.ViewModels;

public class TaxiViewModel : ObservableObject
{
    string _id;
    string _make;
    string _model;
    string _electric;
    string _imagePath;
    public string Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
    public string Make
    {
        get => _make;
        set => SetProperty(ref _make, value);
    }
    public string Model
    {
        get => _model;
        set => SetProperty(ref _model, value);
    }
    public string Electric
    {
        get => _electric;
        set => SetProperty(ref _electric, value);
    } 

    public string ImagePath
    {
        get => _imagePath;
        set => SetProperty(ref _imagePath, value);
    }

    public TaxiViewModel(Taxi taxi)
    {
        Id = taxi.Id;
        Make = taxi.Make;
        Model = taxi.Model;
        Electric = taxi.Electric;
        ImagePath = taxi.ImagePath;
    }
}
