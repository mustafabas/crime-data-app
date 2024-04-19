namespace CrimeData.Entities.Tables
{
    public class ParentGroup : BaseEntity
    {
        public int ApiSourceId { get; set; }
        public string Name { get; set;}
        public string? Code { get; set;}

        public virtual ApiSource ApiSource { get; set; }
        public virtual List<Crime> Crimes { get; set; }
    }
}
