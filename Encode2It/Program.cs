using Encode2It.Encoders;

// Attempt to test.
Console.WriteLine(
    new Listings()
    {
        Listing = [new Listing(), new Listing(), new Listing()]
    }.Generate()
);
Console.WriteLine(new CurrentConditions().Generate());
Console.WriteLine(new ThreeDayForecast().Generate());
Console.WriteLine(new EighteenHourForecast().Generate());
