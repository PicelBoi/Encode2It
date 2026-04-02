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

        while (true)
        {

            // Go though all sources.
            List<Listing> listings = [];

            foreach (ListingInputConfigClass input in config.config.InputConfig.ListingInputs.ListingInputs)
            {
                if (input.Type == "mist_v1")
                {
                    listings.AddRange(await listingsInputs.MistStreaming(input.Value));
                }
                else if (input.Type == "xmltv")
                {
                    listings.AddRange(await listingsInputs.XMLTV(input.Value));
                }
                else
                {
                    logger.Warn($"Unknown type {input.Type}! Skipping...");
                }
            }

            // Sort listings.
            listings = [.. listings.OrderBy(listing => listing.Callsign).OrderBy(listing => listing.ChannelNumber)];

            // Now write!
            string path = Path.Combine(config.config.HeadendConfig.Path, "/OnCable/EXPORT", config.config.HeadendConfig.Id, DateTime.Now.ToString("MMddyyyy") + ".del");
            string fileContent = new Listings() { Listing = listings }.Generate();

            File.WriteAllText(path, fileContent);

            await Task.Delay(config.config.TimingConfig.ListingInt);
        }
    }
}