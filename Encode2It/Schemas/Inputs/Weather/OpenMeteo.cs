namespace Encode2It.Schemas.Inputs.Weather;

public class OpenMeteoCurrentUnits
{
    public string time = "unixtime";
    public string interval = "seconds";
    public string temperature_2m = "F";
    public string weather_code = "wmo code";
    public string surface_pressure = "hPa";
    public string wind_speed_10m = "mp/h";
    public string wind_direction_10m = "";
    public string is_day = "";
}

public class OpenMeteoCurrent
{
    public int time = 0;
    public int interval = 900;
    public double temperature_2m = 0.0;
    public int weather_code = 0;
    public double surface_pressure = 0.0;
    public double wind_speed_10m = 3.5;
    public int wind_direction_10m = 252;
    public int is_day = 0;
}

public class OpenMeteoHourlyUnits
{
    public string time = "unixtime";
    public string temperature_2m = "F";
    public string weather_code = "wmo code";
    public string is_day = "";
}

public class OpenMeteoHourly
{
    public int[] time = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    public double[] temperature_2m = [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,];
    public int[] weather_code = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    public int[] is_day = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
}

public class OpenMeteoDailyUnits
{
    public string time = "unixtime";
    public string temperature_2m_max = "F";
    public string temperature_2m_min = "F";
}

public class OpenMeteoDaily
{
    public int[] time = [0, 0, 0, 0, 0, 0, 0];
    public double[] temperature_2m_max = [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0];
    public double[] temperature_2m_min = [0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0];
}

public class OpenMeteo
{
    public double latitude = 0.0;
    public double longitude = 0.0;
    public double generationtime_ms = 0.0;
    public int utc_offset_seconds = 7200;
    public string timezone = "America/New_York";
    public string timezone_abbreviation = "GMT-5";
    public double elevation = 0.0;
    public OpenMeteoCurrentUnits current_units = new();
    public OpenMeteoCurrent current = new();
    public OpenMeteoHourlyUnits hourly_units = new();
    public OpenMeteoHourly hourly = new();
    public OpenMeteoDailyUnits daily_units = new();
    public OpenMeteoDaily daily = new();
}