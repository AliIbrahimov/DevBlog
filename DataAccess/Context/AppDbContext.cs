using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Statistic> Statistics { get; set; }
    public DbSet<About> About { get; set; }
    public DbSet<AboutAction> AboutActions { get; set; }
    public DbSet<ChooseUs> ChooseUs { get; set; }
    public DbSet<ChooseUsAction> ChooseUsActions { get; set; }
    public DbSet<Developer> Developers { get; set; }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceAction> ServiceActions { get; set; }
    

}
