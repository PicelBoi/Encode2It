using Encode2It.Encoders;
using Encode2It.Core;
using Encode2It.Schemas.Inputs.Listing;
using System.Text.Json;

namespace Encode2It.Inputs;

public class ListingsInputs
{
    private readonly Log Log = new("Listing - Inputs");
    public async Task<List<Listing>> MistStreaming(string api)
    {
        try
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(api);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            MistStreamingPublicChannel[]? publicChannels = JsonSerializer.Deserialize<MistStreamingPublicChannel[]>(responseBody);
            if (publicChannels != null)
            {
                List<Listing> listings = [];
                Random rnd = new();
                foreach (MistStreamingPublicChannel publicChannel in publicChannels)
                {
                    listings.Add(new()
                    {
                        ChannelNumber = publicChannel.channel_number ?? rnd.Next(500, 999),
                        Callsign = publicChannel.channel_id.ToUpper(),
                        Duration = 72000,
                        Titles = [
                            (publicChannel.title ?? publicChannel.channel_id.ToUpper()),
                            "",
                            "",
                            publicChannel.channel_id.ToUpper(),
                            ""
                        ],
                        Subtitle = "",
                        RatingA = "",
                        ProgramType = publicChannel.is_public ? ListingTypes.Default : ListingTypes.Invisible,
                        Description = publicChannel.channel_description ?? "",
                        Category = (publicChannel.channel_category ?? [""])[0]
                    });
                }

                return listings;
            }
            else
            {
                Log.Error("Cannot parse Mist Streaming data.");
                return [];
            }
        }
        catch (Exception ex)
        {
            Log.Error("Unable to grab Mist Streaming data: " + ex.ToString());
            return [];
        }


    }
}
