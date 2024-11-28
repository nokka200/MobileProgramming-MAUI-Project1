using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaxiFleetManager.Models;

public class TaxiDatabase
{
    private static System.Text.Json.JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    private static JsonSerializerOptions writeOptions = new JsonSerializerOptions { WriteIndented = true };
    public async static Task<IEnumerable<Taxi>> GetTaxi()
    {
        string filePath = Path.Combine("/Users/nokka200/Developer/Karelia/Vuosi03/Mobiilikehitys/Yksiloprojekti1/TaxiFleetManager/Resources/Raw","data.json");
        try
        {
            if(!File.Exists(filePath))
            {
                var defaultTaxis = new List<Taxi>();
                string defaultJson = JsonSerializer.Serialize(defaultTaxis, writeOptions);
                await File.WriteAllTextAsync(filePath, defaultJson);
                return Enumerable.Empty<Taxi>();
            } else {
                using FileStream stream = File.OpenRead(filePath);
                IEnumerable<Taxi>? result = await JsonSerializer.DeserializeAsync<IEnumerable<Taxi>>(stream, options);
                Console.WriteLine(filePath + ": file read successfully.");
                return result ?? [];
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error reading file");
            return Enumerable.Empty<Taxi>();
        }
    }

    public async static Task WriteTaxis(ObservableCollection<ViewModels.TaxiViewModel> taxis)
    {
        string json = JsonSerializer.Serialize(taxis, writeOptions);
        string filePath = Path.Combine("/Users/nokka200/Developer/Karelia/Vuosi03/Mobiilikehitys/Yksiloprojekti1/TaxiFleetManager/Resources/Raw","data.json");

        try
        {
            using StreamWriter writer = new(filePath);
            await writer.WriteAsync(json);
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("I/O eror: " + ioEx.Message);
        }
        catch (UnauthorizedAccessException unAuthEx)
        {
            Console.WriteLine("Unauthorized access: " + unAuthEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
