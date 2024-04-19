using CrimeData.Entities;
using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrimeData.Data.Map.Tables
{
    public class CrimeAgainstCategoryMap : EntityTypeConfiguration<CrimeAgainstCategory>
    {
        public override void Configure(EntityTypeBuilder<CrimeAgainstCategory> builder)
        {
            builder.ToTable<CrimeAgainstCategory>("CrimeAgainstCategory");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApiSource).WithMany(x => x.CrimeAgainsCategories).HasForeignKey(x => x.ApiSourceId);
            base.Configure(builder);

        }
    }
}
