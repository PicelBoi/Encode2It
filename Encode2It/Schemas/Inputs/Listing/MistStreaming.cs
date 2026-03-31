namespace Encode2It.Schemas.Inputs.Listing;

public class MistStreamingPublicChannel
{
    public string? title { get; set; }
    public required string channel_id { get; set; }
    public int? channel_number { get; set; }
    public string[]? channel_category { get; set; }
    public string? channel_description { get; set; }
    public bool is_public { get; set; }
    public string? channel_status { get; set; }
    public int viewership { get; set; }
    public string? status { get; set; }
}