using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CrimeData.Data.Map.Tables
{
    public class CrimeMap:EntityTypeConfiguration<Crime>
    {
        public override void Configure(EntityTypeBuilder<Crime> builder)
        {
            builder.ToTable<Crime>("Crime");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApiSource).WithMany(x => x.Crimes).HasForeignKey(x => x.ApiSourceId);
            builder.HasOne(x => x.CrimeAgainstCategory).WithMany(x => x.Crimes).HasForeignKey(x => x.CrimeAgainstCategoryId);
            builder.HasOne(x => x.ParentGroup).WithMany(x => x.Crimes).HasForeignKey(x => x.ParentGroupId);

            base.Configure(builder);
            

        }
    }
}
