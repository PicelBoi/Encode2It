using Encode2It.Encoders;
using Encode2It.Inputs;

// Attempt to test.
ListingsInputs listingsInputs = new();
Console.WriteLine(
    new Listings()
    {
        Listing = await listingsInputs.XMLTV("./xmltv.xml")
    }.Generate()
);
Console.WriteLine(new CurrentConditions().Generate());
Console.WriteLine(new ThreeDayForecast().Generate());
Console.WriteLine(new EighteenHourForecast().Generate());
