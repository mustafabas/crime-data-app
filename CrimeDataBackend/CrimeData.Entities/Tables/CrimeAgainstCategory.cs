namespace CrimeData.Entities.Tables
{
    public class CrimeAgainstCategory:BaseEntity
    {
        public int ApiSourceId { get; set; }
        public string Name { get; set; }
        
        public virtual ApiSource ApiSource { get; set; }
        public virtual List<Crime> Crimes { get; set; }
    }
}
