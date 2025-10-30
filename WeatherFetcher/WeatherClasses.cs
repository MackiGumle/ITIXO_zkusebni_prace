using System;
using System.Xml.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WeatherFetcher;


[XmlRoot(ElementName = "sensor")]
public class Sensor
{

    [XmlElement(ElementName = "type")]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [XmlElement(ElementName = "id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [XmlElement(ElementName = "name")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [XmlElement(ElementName = "place")]
    [JsonPropertyName("place")]
    public object? Place { get; set; }

    [XmlElement(ElementName = "value")]
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}

[XmlRoot(ElementName = "input")]
public class Input
{

    [XmlElement(ElementName = "sensor")]
    [JsonPropertyName("sensor")]
    public List<Sensor>? Sensor { get; set; }
}

[XmlRoot(ElementName = "output")]
public class Output
{

    [XmlElement(ElementName = "sensor")]
    [JsonPropertyName("sensor")]
    public List<Sensor>? Sensor { get; set; }
}

[XmlRoot(ElementName = "variable")]
public class Variable
{

    [XmlElement(ElementName = "sunrise")]
    [JsonPropertyName("sunrise")]
    public string? Sunrise { get; set; }

    [XmlElement(ElementName = "sunset")]
    [JsonPropertyName("sunset")]
    public string? Sunset { get; set; }

    [XmlElement(ElementName = "civstart")]
    [JsonPropertyName("civstart")]
    public string? Civstart { get; set; }

    [XmlElement(ElementName = "civend")]
    [JsonPropertyName("civend")]
    public string? Civend { get; set; }

    [XmlElement(ElementName = "nautstart")]
    [JsonPropertyName("nautstart")]
    public string? Nautstart { get; set; }

    [XmlElement(ElementName = "nautend")]
    [JsonPropertyName("nautend")]
    public string? Nautend { get; set; }

    [XmlElement(ElementName = "astrostart")]
    [JsonPropertyName("astrostart")]
    public string? Astrostart { get; set; }

    [XmlElement(ElementName = "astroend")]
    [JsonPropertyName("astroend")]
    public string? Astroend { get; set; }

    [XmlElement(ElementName = "daylen")]
    [JsonPropertyName("daylen")]
    public string? Daylen { get; set; }

    [XmlElement(ElementName = "civlen")]
    [JsonPropertyName("civlen")]
    public string? Civlen { get; set; }

    [XmlElement(ElementName = "nautlen")]
    [JsonPropertyName("nautlen")]
    public string? Nautlen { get; set; }

    [XmlElement(ElementName = "astrolen")]
    [JsonPropertyName("astrolen")]
    public string? Astrolen { get; set; }

    [XmlElement(ElementName = "moonphase")]
    [JsonPropertyName("moonphase")]
    public int Moonphase { get; set; }

    [XmlElement(ElementName = "isday")]
    [JsonPropertyName("isday")]
    public int Isday { get; set; }

    [XmlElement(ElementName = "bio")]
    [JsonPropertyName("bio")]
    public int Bio { get; set; }

    [XmlElement(ElementName = "pressure_old")]
    [JsonPropertyName("pressure_old")]
    public double PressureOld { get; set; }

    [XmlElement(ElementName = "temperature_avg")]
    [JsonPropertyName("temperature_avg")]
    public double TemperatureAvg { get; set; }

    [XmlElement(ElementName = "agl")]
    [JsonPropertyName("agl")]
    public int Agl { get; set; }

    [XmlElement(ElementName = "fog")]
    [JsonPropertyName("fog")]
    public int Fog { get; set; }

    [XmlElement(ElementName = "lsp")]
    [JsonPropertyName("lsp")]
    public int Lsp { get; set; }
}

[XmlRoot(ElementName = "s")]
public class S
{

    [XmlAttribute(AttributeName = "id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [XmlAttribute(AttributeName = "min")]
    [JsonPropertyName("min")]
    public double Min { get; set; }

    [XmlAttribute(AttributeName = "max")]
    public double Max { get; set; }
}

[XmlRoot(ElementName = "minmax")]
public class Minmax
{

    [XmlElement(ElementName = "s")]
    [JsonPropertyName("s")]
    public List<S>? S { get; set; }
}

[XmlRoot(ElementName = "wario")]
public class Wario
{

    [XmlElement(ElementName = "input")]
    [JsonPropertyName("input")]
    public Input? Input { get; set; }

    [XmlElement(ElementName = "output")]
    [JsonPropertyName("output")]
    public Output? Output { get; set; }

    [XmlElement(ElementName = "variable")]
    [JsonPropertyName("variable")]
    public Variable? Variable { get; set; }

    [XmlElement(ElementName = "minmax")]
    [JsonPropertyName("minmax")]
    public Minmax? Minmax { get; set; }

    [XmlAttribute(AttributeName = "degree")]
    [JsonPropertyName("degree")]
    public string? Degree { get; set; }

    [XmlAttribute(AttributeName = "pressure")]
    [JsonPropertyName("pressure")]
    public string? Pressure { get; set; }

    [XmlAttribute(AttributeName = "serial_number")]
    [JsonPropertyName("serial_number")]
    public string? SerialNumber { get; set; }

    [XmlAttribute(AttributeName = "model")]
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [XmlAttribute(AttributeName = "firmware")]
    [JsonPropertyName("firmware")]
    public string? Firmware { get; set; }

    [XmlAttribute(AttributeName = "runtime")]
    [JsonPropertyName("runtime")]
    public int Runtime { get; set; }

    [XmlAttribute(AttributeName = "freemem")]
    [JsonPropertyName("freemem")]
    public int Freemem { get; set; }

    [XmlAttribute(AttributeName = "date")]
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [XmlAttribute(AttributeName = "time")]
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    [XmlAttribute(AttributeName = "language")]
    [JsonPropertyName("language")]
    public int Language { get; set; }

    [XmlAttribute(AttributeName = "pressure_type")]
    [JsonPropertyName("pressure_type")]
    public int PressureType { get; set; }

    [XmlAttribute(AttributeName = "r")]
    [JsonPropertyName("r")]
    public int R { get; set; }

    [XmlAttribute(AttributeName = "bip")]
    [JsonPropertyName("bip")]
    public int Bip { get; set; }

    [XmlText]
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

