using Encode2It.Core;

namespace Encode2It.Encoders;

public enum WeatherIcons
{
    Sunny = 1,
    MostlySunny = 2,
    PartlySunny = 3,
    IntermittentClouds = 4,
    Hazy = 5,
    MostlyCloudy = 6,
    Cloudy = 7,
    Overcast = 8,
    Fog = 11,
    Showers = 12,
    MostlyCloudyShowers = 13,
    PartlyCloudyShowers = 14,
    Thunderstorms = 15,
    MostlyCloudyTStorms = 16,
    PartlyCloudyTStorms = 17,
    Rain = 18,
    Flurries = 19,
    MostlyCloudyFlurries = 20,
    PartlyCloudyFlurries = 21,
    Snow = 22,
    MostlyCloudySnow = 23,
    Ice = 24,
    Sleet = 25,
    FreezingRain = 26,
    MixedRnAndSn = 29,
    Hot = 30,
    Cold = 31,
    Windy = 32,
}

public class WeatherInfo
{
    public string HeadendId { get; set; } = "ZAP2IT";
    public string Location { get; set; } = "Kirby";
    public int Temperature { get; set; } = 0;
    public int HighTemp { get; set; } = 0;
    public int LowTemp { get; set; } = 0;
    public WeatherIcons Icon { get; set; } = WeatherIcons.Sunny;
    public string DaypartTag { get; set; } = "AFT";
    public string DaypartStr { get; set; } = "Afternoon";
    public string WindDirection { get; set; } = "N";
    public double Pressure = 0.00;
    public int WindSpeed = 0;
    public string Condition = "CLEAR";
}

public class CurrentConditions
{
    public WeatherInfo WxInfo { get; set; } = new();
    public string Generate()
    {
        Delimited delimited = new();
        List<string[]> lines = [];

        lines.Add(
            [
                WxInfo.HeadendId,
                WxInfo.Location,
                WxInfo.Temperature.ToString(),
                WxInfo.Condition,
                WxInfo.WindDirection,
                WxInfo.Icon.ToString(),
                WxInfo.HighTemp.ToString(),
                WxInfo.Pressure.ToString(),
                WxInfo.LowTemp.ToString(),
                WxInfo.Temperature.ToString()
            ]
        );

        delimited.Lines = [.. lines];
        return delimited.Generate();
    }
}

public class ThreeDayForecast
{
    public WeatherInfo[] WxInfo { get; set; } = [new(), new(), new()];
    public string Generate()
    {
        Delimited delimited = new();
        List<string[]> lines = [];

        lines.Add(
            [
                WxInfo[0].HeadendId,
                WxInfo[0].Location,
                WxInfo[0].DaypartTag,
                WxInfo[0].HighTemp.ToString().PadLeft(2, '0'),
                WxInfo[0].LowTemp.ToString().PadLeft(2, '0'),
                WxInfo[1].DaypartTag,
                WxInfo[1].HighTemp.ToString().PadLeft(2, '0'),
                WxInfo[1].LowTemp.ToString().PadLeft(2, '0'),
                WxInfo[2].DaypartTag,
                WxInfo[2].HighTemp.ToString().PadLeft(2, '0'),
                WxInfo[2].LowTemp.ToString().PadLeft(2, '0'),
            ]
        );

        delimited.Lines = [.. lines];
        return delimited.Generate();
    }
}

public class EighteenHourForecast
{
    public WeatherInfo[] WxInfo { get; set; } = [new(), new(), new()];
    public string Generate()
    {
        Delimited delimited = new();
        List<string[]> lines = [];

        lines.Add(
            [
                WxInfo[0].HeadendId,
                WxInfo[0].Location,
                WxInfo[0].DaypartTag,
                WxInfo[0].DaypartStr,
                WxInfo[0].HighTemp.ToString().PadLeft(2, '0'),
                WxInfo[0].LowTemp.ToString().PadLeft(2, '0'),
                WxInfo[1].DaypartTag,
                WxInfo[1].DaypartStr,
                WxInfo[1].HighTemp.ToString().PadLeft(2, '0'),
                WxInfo[1].LowTemp.ToString().PadLeft(2, '0'),
                WxInfo[2].DaypartTag,
                WxInfo[2].DaypartStr,
                WxInfo[2].HighTemp.ToString().PadLeft(2, '0'),
                WxInfo[2].LowTemp.ToString().PadLeft(2, '0'),
            ]
        );

        delimited.Lines = [.. lines];
        return delimited.Generate();
    }
}