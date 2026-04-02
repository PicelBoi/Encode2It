namespace Encode2It.Schemas.Inputs.Weather;

public class OpenMeteoCurrentUnits
{
    public string time { get; set; } = "unixtime";
    public string interval { get; set; } = "seconds";
    public string temperature_2m { get; set; } = "F";
    public string weather_code { get; set; } = "wmo code";
    public string surface_pressure { get; set; } = "hPa";
    public string wind_speed_10m { get; set; } = "mp/h";
    public string wind_direction_10m { get; set; } = "";
    public string is_day { get; set; } = "";
}

public class OpenMeteoCurrent
{
    public int time { get; set; } = 0;
    public int interval { get; set; } = 900;
    public double temperature_2m { get; set; } = 0.0;
    public int weather_code { get; set; } = 0;
    public double surface_pressure { get; set; } = 0.0;
    public double wind_speed_10m { get; set; } = 3.5;
    public int wind_direction_10m { get; set; } = 252;
    public int is_day { get; set; } = 0;
}

public class OpenMeteoHourlyUnits
{
    public string time { get; set; } = "unixtime";
    public string temperature_2m { get; set; } = "F";
    public string weather_code { get; set; } = "wmo code";
    public string is_day { get; set; } = "";
}

public class OpenMeteoHourly
{
    public int[] time { get; set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    public double[] temperature_2m { get; set; } = [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,];
    public int[] weather_code { get; set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    public int[] is_day { get; set; } = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
}

public class OpenMeteoDailyUnits
{
    public string time { get; set; } = "unixtime";
    public string temperature_2m_max { get; set; } = "F";
    public string temperature_2m_min { get; set; } = "F";
}

public class OpenMeteoDaily
{
    public int[] time { get; set; } = [0, 0, 0, 0, 0, 0, 0];
    public double[] temperature_2m_max { get; set; } = [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0];
    public double[] temperature_2m_min { get; set; } = [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0];
}

public class OpenMeteo
{
    public double latitude { get; set; } = 0.0;
    public double longitude { get; set; } = 0.0;
    public double generationtime_ms { get; set; } = 0.0;
    public int utc_offset_seconds { get; set; } = 7200;
    public string timezone { get; set; } = "America/New_York";
    public string timezone_abbreviation { get; set; } = "GMT-5";
    public double elevation { get; set; } = 0.0;
    public OpenMeteoCurrentUnits current_units { get; set; } = new();
    public OpenMeteoCurrent current { get; set; } = new();
    public OpenMeteoHourlyUnits hourly_units { get; set; } = new();
    public OpenMeteoHourly hourly { get; set; } = new();
    public OpenMeteoDailyUnits daily_units { get; set; } = new();
    public OpenMeteoDaily daily { get; set; } = new();
}