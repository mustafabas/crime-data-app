using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrimeData.Data.Map.Tables
{
    public class ParentGroupMap : EntityTypeConfiguration<ParentGroup>
    {
        public override void Configure(EntityTypeBuilder<ParentGroup> builder)
        {
            builder.ToTable<ParentGroup>("ParentGroup");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApiSource).WithMany(x => x.ParentGroups).HasForeignKey(x => x.ApiSourceId);

            base.Configure(builder);

        }
    }
}
