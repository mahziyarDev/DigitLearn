using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CoreModule.Infrastructure.Persistent.Category;

public class CategoryConfig : IEntityTypeConfiguration<Domain.CategoryAgg.Models.Category>
{
    public void Configure(EntityTypeBuilder<Domain.CategoryAgg.Models.Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Slug)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);


        builder.HasMany<Domain.CategoryAgg.Models.Category>()
            .WithOne().OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x => x.ParentId);
    }
}