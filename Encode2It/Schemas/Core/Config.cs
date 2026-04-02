using System.Xml.Serialization;
using System.Xml;

namespace Encode2It.Schemas.Core;

[XmlRoot(ElementName = "ListingInput")]
public class ListingInputConfigClass
{
    [XmlAnyElement(Name = "TypeComment")]
    public static XmlComment TypeComment { get { return new XmlDocument().CreateComment("This sets the type of input this is.\n\n Values:\n  - mist_v1\n  - xmltv"); } set { } }

    [XmlElement(ElementName = "Type")]
    public string Type { get; set; } = "";

    [XmlAnyElement(Name = "ValueComment")]
    public static XmlComment ValueComment { get { return new XmlDocument().CreateComment("This sets the value of the type (ex: api url, path to file, etc).\nExamples:\n  - mist_v1:\n    - https://api.mistweather.com/api/public-channels\n  - xmltv:\n    - ./xmltv.xml"); } set { } }

    [XmlElement(ElementName = "Value")]
    public string Value { get; set; } = "";

    [XmlAnyElement(Name = "KeyEnabledComment")]
    public static XmlComment KeyEnabledComment { get { return new XmlDocument().CreateComment("If set to true, the supplied API key is sent to the provider (DEPENDS ON TYPE)"); } set { } }

    [XmlElement(ElementName = "KeyEnabled")]
    public bool KeyEnabled { get; set; } = false;

    [XmlAnyElement(Name = "KeyComment")]
    public static XmlComment KeyComment { get { return new XmlDocument().CreateComment("This sets the API key, and will be sent if KeyEnabled is set to true. (DEPENDS ON TYPE)"); } set { } }

    [XmlElement(ElementName = "Key")]
    public string Key { get; set; } = "";
}

[XmlRoot(ElementName = "WeatherInput")]
public class WeatherInputConfigClass
{

    [XmlAnyElement(Name = "TypeComment")]
    public static XmlComment TypeComment { get { return new XmlDocument().CreateComment("This sets the type of input this is.\n\n Values:\n  - openmeteo"); } set { } }

    [XmlElement(ElementName = "Type")]
    public string Type { get; set; } = "INSERT_TYPE_HERE";

    [XmlAnyElement(Name = "LocationNameComment")]
    public static XmlComment LocationNameComment { get { return new XmlDocument().CreateComment("The location name as shown on the forecasts."); } set { } }

    [XmlElement(ElementName = "LocationName")]
    public string LocationName { get; set; } = "INSERT_LOCATION_NAME_HERE";

    [XmlAnyElement(Name = "ValueComment")]
    public static XmlComment ValueComment { get { return new XmlDocument().CreateComment("This sets the value of the type (ex: api url, path to file, etc).\nExamples:\n  - openmeteo:\n    - https://api.open-meteo.com (if commercial)\n    - https://customer-api.open-meteo.com (if non-commercial)"); } set { } }

    [XmlElement(ElementName = "Value")]
    public string Value { get; set; } = "INSERT_VALUE_HERE";

    [XmlAnyElement(Name = "KeyEnabledComment")]
    public static XmlComment KeyEnabledComment { get { return new XmlDocument().CreateComment("If set to true, the supplied API key is sent to the provider (DEPENDS ON TYPE)"); } set { } }

    [XmlElement(ElementName = "KeyEnabled")]
    public bool KeyEnabled { get; set; } = false;

    [XmlAnyElement(Name = "KeyComment")]
    public static XmlComment KeyComment { get { return new XmlDocument().CreateComment("This sets the API key, and will be sent if KeyEnabled is set to true. (DEPENDS ON TYPE)"); } set { } }

    [XmlElement(ElementName = "Key")]
    public string Key { get; set; } = "";
}

[XmlRoot(ElementName = "InputConfig")]
public class InputConfigClass
{
    [XmlAnyElement(Name = "WeatherInputComment")]
    public static XmlComment WeatherInputComment { get { return new XmlDocument().CreateComment("This sets the provider for the weather data provided by this encoder. Only one can be set."); } set { } }

    [XmlElement(ElementName = "WeatherInput")]
    public WeatherInputConfigClass Weather { get; set; } = new();

    [XmlAnyElement(Name = "LisitingInputComment")]
    public static XmlComment ListingInputComment { get { return new XmlDocument().CreateComment("This sets the provider(s) for the listing data provided by this encoder. Multiple can be set."); } set { } }

    [XmlElement(ElementName = "ListingInputs")]
    public ListingInputConfigClass[] ListingInputs { get; set; } = [new()];
}

[XmlRoot(ElementName = "HeadendConfig")]
public class HeadendConfigClass
{
    [XmlAnyElement(Name = "IdComment")]
    public static XmlComment IdComment { get { return new XmlDocument().CreateComment("This sets the ID of the Zap2It headend. Do not change if you don't know what you're doing."); } set { } }

    [XmlElement(ElementName = "Id")]
    public string Id { get; set; } = "ZAP2IT";

    [XmlAnyElement(Name = "PathComment")]
    public static XmlComment PathComment { get { return new XmlDocument().CreateComment("This is where the Zap2It program is installed. Do not change if you don't know what you're doing."); } set { } }

    [XmlElement(ElementName = "Path")]
    public string Path { get; set; } = "C:\\ZAP2IT\\";

}

[XmlRoot(ElementName = "Encode2ItConfig")]
public class ConfigSchema
{
    [XmlAnyElement(Name = "IntroComment")]
    public static XmlComment IntroComment { get { return new XmlDocument().CreateComment("This is the Encode2It config file. For more information, check the wiki."); } set { } }
    [XmlAnyElement(Name = "HeadendComment")]
    public static XmlComment HeadendComment { get { return new XmlDocument().CreateComment("This is where headend-specific config data is set."); } set { } }

    [XmlElement(ElementName = "HeadendConfig")]
    public HeadendConfigClass HeadendConfig { get; set; } = new();

    [XmlAnyElement(Name = "InputComment")]
    public static XmlComment InputComment { get { return new XmlDocument().CreateComment("This is where input-specific config data is set."); } set { } }

    [XmlElement(ElementName = "InputConfig")]
    public InputConfigClass InputConfig { get; set; } = new();
}