using CrimeData.Entities;
using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrimeData.Data.Map.Tables
{
    public class CityMap:EntityTypeConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable<City>("City");
            builder.HasKey(x => x.Id);
            base.Configure(builder);
        }
    }
}
