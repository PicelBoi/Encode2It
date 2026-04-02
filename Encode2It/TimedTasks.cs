using System.Runtime.CompilerServices;
using Encode2It.Core;
using Encode2It.Encoders;
using Encode2It.Inputs;
using Encode2It.Schemas.Core;

namespace Encode2It;

public class TimedTasks
{
    Config config;

    public TimedTasks(Config configobj)
    {
        config = configobj;
    }

    public async Task ListingLoop()
    {
        // Make new ListingsInputs.
        ListingsInputs listingsInputs = new();

        // Make new logger.
        Logger logger = new("TimedTasks - ListingLoop");

        logger.Info("Starting listing loop.");

        while (true)
        {
            logger.Info("Listing loop start!");
            // Go though all sources.
            List<Listing> listings = [];

            foreach (ListingInputConfigClass input in config.config.InputConfig.ListingInputs.ListingInputs)
            {
                if (input.Type == "mist_v1")
                {
                    logger.Info("Generating listings from Mist Streaming V1 input...");
                    listings.AddRange(await listingsInputs.MistStreaming(input.Value));
                    logger.Info("Finished generating listings from Mist Streaming V1 input.");
                }
                else if (input.Type == "xmltv")
                {
                    logger.Info("Generating listings from XMLTV input...");
                    listings.AddRange(await listingsInputs.XMLTV(input.Value));
                    logger.Info("Finished generating listings from XMLTV input.");
                }
                else
                {
                    logger.Warn($"Unknown type {input.Type}! Skipping...");
                }
            }

            logger.Info("Sorting listings...");
            // Sort listings.
            listings = [.. listings.OrderBy(listing => listing.Callsign).OrderBy(listing => listing.ChannelNumber)];
            logger.Info("Sorted!");

            logger.Info("Writing down data...");
            // Now write!
            string path = Path.Combine(config.config.HeadendConfig.Path, "/OnCable/EXPORT", config.config.HeadendConfig.Id, DateTime.Now.ToString("MMddyyyy") + ".del");
            logger.Debug("Path: " + path);
            string fileContent = new Listings() { Listing = listings }.Generate();
            logger.Debug("File Content:\n" + fileContent);

            File.WriteAllText(path, fileContent);
            logger.Info("Wrote down!");
            logger.Info($"Now waiting for {config.config.TimingConfig.ListingInt} for next loop...");

            await Task.Delay(config.config.TimingConfig.ListingInt);
        }
    }

    public async Task WeatherLoop()
    {
        // Make new WeatherInputs.
        WeatherInputs weatherInputs = new();

        // Make new logger.
        Logger logger = new("TimedTasks - WeatherLoop");

        // Enabled bool
        bool enabled = true;

        // Check weather input
        WeatherInputConfigClass weatherInput = config.config.InputConfig.Weather;

        while (enabled)
        {

            WeatherDataset weatherDataset = new();

            if (weatherInput.Type == "openmeteo")
            {
                weatherDataset = await weatherInputs.OpenMeteoWx(weatherInput.Value, weatherInput.KeyEnabled, weatherInput.Key);
            }
            else
            {
                enabled = false;
                logger.Warn($"Unknown weather type {weatherInput.Type}! Stopping weather data generation...");
            }

            // Now write!
            string path = Path.Combine(config.config.HeadendConfig.Path, "/OnCable/EXPORT", config.config.HeadendConfig.Id, "uscur.txt");
            File.WriteAllText(path, weatherDataset.currentConditions.Generate());

            path = Path.Combine(config.config.HeadendConfig.Path, "/OnCable/EXPORT", config.config.HeadendConfig.Id, "us3day.txt");
            File.WriteAllText(path, weatherDataset.threeDayForecast.Generate());

            path = Path.Combine(config.config.HeadendConfig.Path, "/OnCable/EXPORT", config.config.HeadendConfig.Id, "18hour.txt");
            File.WriteAllText(path, weatherDataset.eighteenHourForecast.Generate());

            await Task.Delay(config.config.TimingConfig.WeatherInt);
        }
    }
}