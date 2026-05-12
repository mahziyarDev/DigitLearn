using Common.Infrastructure;
using CoreModule.Infrastructure.Persistent.Course;
using CoreModule.Infrastructure.Persistent.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent;

public class CoreModuleEfContext : BaseEfContext<CoreModuleEfContext>
{   
    /// <summary></summary>
    /// <param name="options"></param>
    /// <param name="mediator"></param>
    public CoreModuleEfContext(DbContextOptions<CoreModuleEfContext> options, IMediator mediator) : base(options, mediator)
    {
    }

    public DbSet<Domain.CourseAgg.Models.Course> Courses { get; set; }
    public DbSet<Domain.TeacherAgg.Models.Teacher> Teachers { get; set; }
    public DbSet<Domain.CategoryAgg.Models.Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfig).Assembly);
        base.OnModelCreating(modelBuilder);
    }


}