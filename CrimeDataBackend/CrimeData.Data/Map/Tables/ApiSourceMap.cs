using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrimeData.Data.Map.Tables
{
    public class ApiSourceMap:EntityTypeConfiguration<ApiSource>
    {
        public override void Configure(EntityTypeBuilder<ApiSource> builder)
        {
            builder.ToTable<ApiSource>("ApiSource");
            builder.HasKey(x => x.Id);
            base.Configure(builder);

        }
    }
}
