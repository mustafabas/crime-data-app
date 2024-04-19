using System.Text.Json.Serialization;

namespace CrimeData.Services.Services.Models
{
    public record InsertCrimeModel
    {
        public string ReportNumber { get; init; }

        public string OffenseId { get; init; }

        public DateTime OffenseStartDateTime { get; init; }

        public DateTime ReportDateTime { get; init; }

        public string GroupAB { get; init; }

        public string CrimeAgainstCategory { get; init; }

        public string OffenseParentGroup { get; init; }

        public string Offense { get; init; }

        public string OffenseCode { get; init; }

        public string Precinct { get; init; }

        public string Sector { get; init; }

        public string Beat { get; init; }

        public string Mcpp { get; init; }

        public string BlockAddress { get; init; }

        public string Longitude { get; init; }

        public string Latitude { get; init; }


    }
}
