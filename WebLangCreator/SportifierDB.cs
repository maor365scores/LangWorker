using Microsoft.EntityFrameworkCore;

namespace WebLangCreator;

public class SportifierDB : DbContext
{
    public DbSet<DictValuesRecord> DictValues { get; set; }
    public DbSet<DictTermsRecord> DictTerms { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Athlete> Athletes { get; set; }
    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Language> Languages { get; set; }

    public SportifierDB(DbContextOptions options)
        : base(options)
    {
    }
}