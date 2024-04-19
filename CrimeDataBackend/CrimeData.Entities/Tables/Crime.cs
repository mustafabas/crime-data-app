namespace CrimeData.Entities.Tables
{
    public class Crime : BaseEntity
    {
        public int ApiSourceId { get; set; }
        public int? CityId { get; set; }
        public int? ParentGroupId { get; set; }
        public int? CrimeAgainstCategoryId { get; set; }
        public string ReportNumber { get; set; }
        public DateTime OffenseStartDatetime { get; set; }
        public DateTime ReportDateTime { get; set; }
        public double? Longtitde { get; set; }
        public double? Latitude { get; set; }
        public string Offense { get; set; }
        public string? Address { get; set; }

        public virtual ApiSource ApiSource { get; set; }
        public virtual City? City { get; set; }
        public virtual ParentGroup? ParentGroup { get; set; }

        public virtual CrimeAgainstCategory? CrimeAgainstCategory { get; set; }


    }
}
