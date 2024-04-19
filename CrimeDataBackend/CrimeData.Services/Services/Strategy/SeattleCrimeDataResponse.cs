using System.Text.Json.Serialization;


namespace CrimeData.Services.Services.Strategy
{
    public record SeattleCrimeDataResponse
    {
        [JsonPropertyName("report_number")]
        public string ReportNumber { get; init; }

        [JsonPropertyName("offense_id")]
        public string OffenseId { get; init; }

        [JsonPropertyName("offense_start_datetime")]
        public DateTime OffenseStartDateTime { get; init; }

        [JsonPropertyName("report_datetime")]
        public DateTime ReportDateTime { get; init; }

        [JsonPropertyName("group_a_b")]
        public string GroupAB { get; init; }

        [JsonPropertyName("crime_against_category")]
        public string CrimeAgainstCategory { get; init; }

        [JsonPropertyName("offense_parent_group")]
        public string OffenseParentGroup { get; init; }

        [JsonPropertyName("offense")]
        public string Offense { get; init; }

        [JsonPropertyName("offense_code")]
        public string OffenseCode { get; init; }

        [JsonPropertyName("precinct")]
        public string Precinct { get; init; }

        [JsonPropertyName("sector")]
        public string Sector { get; init; }

        [JsonPropertyName("beat")]
        public string Beat { get; init; }

        [JsonPropertyName("mcpp")]
        public string Mcpp { get; init; }

        [JsonPropertyName("_100_block_address")]
        public string BlockAddress { get; init; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; init; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; init; }
    }
}
