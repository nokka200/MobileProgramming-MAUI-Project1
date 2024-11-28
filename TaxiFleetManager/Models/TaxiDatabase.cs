using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaxiFleetManager.Models;

public class TaxiDatabase
{
    /*
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
    */
    
    private readonly static JsonSerializerOptions writeOptions = new()
    {
        WriteIndented = true
    };
    private readonly static JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true // Case-insensitive property matching
    };
    public async static Task<IEnumerable<Taxi>> GetTaxi()
    {
        // Set up the file path.
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                var defaultItems = new List<Taxi>(); // Default empty list.
                string defaultJson = JsonSerializer.Serialize(defaultItems, writeOptions);
                await File.WriteAllTextAsync(filePath, defaultJson);
                return [];
            }
            else
            {
                // Read the file content as a stream.
                using FileStream stream = File.OpenRead(filePath);
                IEnumerable<Taxi>? result = await JsonSerializer.DeserializeAsync<IEnumerable<Taxi>>(stream, options);
                Console.WriteLine(filePath + ": file read successfully.");
                return result ?? [];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to read data from file. {ex.Message}");
            return [];
        }
    }

    public async static Task WriteTaxis(ObservableCollection<ViewModels.TaxiViewModel> items)
    {
        string json = JsonSerializer.Serialize(items, writeOptions);
        // Set up the file path.
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

        try
        {
            // Write the JSON string to a file using StreamWriter class.
            using StreamWriter writer = new(filePath);
            await writer.WriteAsync(json);
        }
        catch (IOException ioEx)
        {
            // Handle I/O errors.
            Console.WriteLine($"I/O error occurred: {ioEx.Message}");
        }
        catch (UnauthorizedAccessException uaEx)
        {
            // Handle permission-related errors.
            Console.WriteLine($"Permission error: {uaEx.Message}");
        }
        catch (Exception ex)
        {
            // Handle any other errors.
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
