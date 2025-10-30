using System.Text.Json;
using System.Xml.Serialization;

namespace WeatherFetcher;

class Program
{
    static async Task<string> FetchWeatherData(string url)
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    static async Task Main(string[] args)
    {
        while (true)
        {
            string? weatherDataString = null;

            try
            {
                weatherDataString = await FetchWeatherData("https://pastebin.com/raw/PMQueqDV");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather data: {ex.Message}");
            }

            if (!string.IsNullOrEmpty(weatherDataString))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(Wario));
                    using var reader = new StringReader(weatherDataString);
                    var weatherData = (Wario?)serializer.Deserialize(reader);

                    if (weatherData != null)
                    {
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonSerializer.Serialize(weatherData, options);
                        Console.WriteLine(jsonString);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing weather data: {ex.Message}");
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(10));
        }


    }
}
