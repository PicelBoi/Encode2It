using Encode2It.Core;

namespace Encode2It.Encoders;

public enum ListingTypes
{
    Default = 0,
    Movies = 3,
    Sports = 6,
    News = 25,
    Kids = 12,
    Invisible = 63
}

public class Listing
{
    public int ChannelNumber { get; set; } = 0;
    public DateTime Time { get; set; } = DateTime.Now;
    public string Callsign { get; set; } = "UNKNTV";
    public int Duration { get; set; } = 60;
    public string[] Titles { get; set; } = [
        "Unknown Program",
        "Unknown Program",
        "Unknown Pro.",
        "Unknown",
        "Unkn"
    ];
    public string Subtitle { get; set; } = "Episode N/A";
    public int Episode { get; set; } = 0;
    // Unknown.
    public string UnknownA { get; set; } = "";
    public int StarRating { get; set; } = 0;
    public int Year { get; set; } = 0000;
    public ListingTypes ProgramType { get; set; } = ListingTypes.Default;
    public string Category { get; set; } = "";
    public string Actor { get; set; } = "";
    public string RatingA { get; set; } = "N/A";
    public string RatingAdvisories { get; set; } = "";
    public string QualifierA { get; set; } = "";
    public string QualifierB { get; set; } = "";
    public string Description { get; set; } = "";
    public string UnknownB { get; set; } = "";
    public string RatingB { get; set; } = "";
    public string UnknownC { get; set; } = "";
    public string Country { get; set; } = "";
    public string TMSId { get; set; } = "";
    public string UnknownD { get; set; } = "";
    public string SubCh { get; set; } = "";
    public string Subtitles { get; set; } = "";
    public bool IsHD { get; set; } = false;
}

public class Listings
{
    public List<Listing> Listing { get; set; } = [];
    public string Generate()
    {
        Delimited delimited = new();
        List<string[]> lines = [];
        foreach (Listing listing in Listing)
        {
            lines.Add(
                [
                    listing.ChannelNumber.ToString(),
                    listing.Time.ToString("MM/dd/yyyy"),
                    listing.Time.ToString("HH:mm"),
                    listing.Callsign,
                    listing.Duration.ToString(),
                    listing.Titles[0],
                    listing.Titles[1],
                    listing.Titles[2],
                    listing.Titles[3],
                    listing.Titles[4],
                    listing.Episode.ToString(),
                    listing.UnknownA,
                    new string('*', listing.StarRating),
                    listing.Year.ToString(),
                    listing.ProgramType.ToString().PadLeft(2, '0'),
                    listing.Category,
                    listing.Actor,
                    listing.RatingA,
                    listing.RatingAdvisories,
                    listing.Description,
                    listing.Subtitles,
                    listing.Subtitle,
                    listing.Description,
                    listing.UnknownB,
                    listing.RatingB,
                    listing.UnknownC,
                    listing.Country,
                    listing.TMSId,
                    listing.UnknownD,
                    listing.IsHD ? "Y" : "N",
                    listing.SubCh
                ]
            );
        }
        delimited.Lines = [.. lines];
        return delimited.Generate();
    }
}