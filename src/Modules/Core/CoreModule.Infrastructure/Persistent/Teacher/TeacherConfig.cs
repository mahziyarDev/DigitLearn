using CoreModule.Infrastructure.Persistent.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreModule.Infrastructure.Persistent.Teacher;

public class TeacherConfig : IEntityTypeConfiguration<Domain.TeacherAgg.Models.Teacher>
{
    public void Configure(EntityTypeBuilder<Domain.TeacherAgg.Models.Teacher> builder)
    {
        builder.ToTable("Teacher");
        
        builder.HasKey(b => b.Id);
        builder.HasIndex(b => b.UserName).IsUnique();

        builder.Property(b => b.UserName)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(20);


        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<Domain.TeacherAgg.Models.Teacher>(f => f.UserId);
    }
}