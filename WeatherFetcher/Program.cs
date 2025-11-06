using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace WeatherFetcher;

class Program
{
    static async Task<string?> FetchWeatherData(HttpClient client, string url)
    {
        // Random rnd = new Random();
        // int fail = rnd.Next(1, 11);

        HttpResponseMessage response;
        // if (fail <= 5)
        //     response = await client.GetAsync(url);
        // else
        //     response = await client.GetAsync("https://invalid.url");

        response = await client.GetAsync(url);

        return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;
    }

    static public async Task CreateDatabaseIfNotExists(string dbPath)
    {
        const string sql = @"
            CREATE TABLE IF NOT EXISTS Weather (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Timestamp TEXT NOT NULL,
                JsonData TEXT,
                StationStatus INTEGER NOT NULL
            );";

        using var cn = new SqliteConnection($"Data Source={dbPath};");
        using var cmd = new SqliteCommand(sql, cn);

        await cn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    static public async Task WriteWeatherData(SqliteConnection dbConnection, DateTime timestamp, string? jsonData, int stationStatus)
    {
        const string sql = @"
            INSERT INTO Weather (Timestamp, JsonData, StationStatus)
            VALUES (@Timestamp, @JsonData, @StationStatus);";

        using var cmd = new SqliteCommand(sql, dbConnection);

        cmd.Parameters.Add("@Timestamp", SqliteType.Text).Value = timestamp.ToString();
        cmd.Parameters.Add("@JsonData", SqliteType.Text).Value = jsonData ?? (object)DBNull.Value;
        cmd.Parameters.Add("@StationStatus", SqliteType.Integer).Value = stationStatus;

        await cmd.ExecuteNonQueryAsync();
    }

    static async Task Main(string[] args)
    {
        string dbPath = "WeatherDB.db";
        string apiUrl = "https://pastebin.com/raw/PMQueqDV";
        int fetchIntervalSeconds = 3600;

        var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .Build();

        dbPath = config["DbPath"] ?? dbPath;
        apiUrl = config["ApiUrl"] ?? apiUrl;
        fetchIntervalSeconds = int.TryParse(config["FetchIntervalSeconds"], out var interval) ? interval : fetchIntervalSeconds;

        using HttpClient client = new HttpClient();
        using SqliteConnection dbConnection = new SqliteConnection($"Data Source={dbPath};");

        try
        {
            await CreateDatabaseIfNotExists(dbPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating database: {ex.Message}");
            return;
        }

        while (true)
        {
            try
            {
                await dbConnection.OpenAsync();
                string? weatherDataString = await FetchWeatherData(client, apiUrl);

                if (!string.IsNullOrEmpty(weatherDataString))
                {
                    var serializer = new XmlSerializer(typeof(Wario));
                    using var reader = new StringReader(weatherDataString);

                    var weatherData = (Wario?)serializer.Deserialize(reader);

                    if (weatherData is not null)
                    {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonSerializer.Serialize(weatherData, options);

                        await WriteWeatherData(dbConnection, DateTime.UtcNow, jsonString, 1);
                        Console.WriteLine("Saved Weather Data.");
                    }
                }
                else
                {
                    Console.WriteLine("No weather data received.");
                    await WriteWeatherData(dbConnection, DateTime.UtcNow, null, 0);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
                await WriteWeatherData(dbConnection, DateTime.UtcNow, null, 0);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error probably deserialization: {ex.Message}");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"Error serialization: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.StackTrace}: {ex.Message}");
            }
            finally
            {
                await dbConnection.CloseAsync();
            }

            await Task.Delay(TimeSpan.FromSeconds(fetchIntervalSeconds));
        }
    }
}
