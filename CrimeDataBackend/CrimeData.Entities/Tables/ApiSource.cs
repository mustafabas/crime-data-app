namespace CrimeData.Entities.Tables
{
    public class ApiSource:BaseEntity
    {
        public string CountryCode { get; set; }
        public string ServiceEndpoint { get; set; }


        public virtual List<Crime> Crimes { get; set; }
        public virtual List<CrimeAgainstCategory> CrimeAgainsCategories  { get; set; }
        public virtual List<ParentGroup> ParentGroups { get; set; }

    }
}
