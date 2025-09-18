using System;
using Microsoft.EntityFrameworkCore;

namespace Ingfrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public DbSet<Domain.Entities.Audience> Audiences => Set<Domain.Entities.Audience>();
    public DbSet<Domain.Entities.Benefit> Benefits => Set<Domain.Entities.Benefit>();
    public DbSet<Domain.Entities.AudienceBenefit> AudienceBenefits => Set<Domain.Entities.AudienceBenefit>();
    public DbSet<Domain.Entities.Company> Companies => Set<Domain.Entities.Company>();
    public DbSet<Domain.Entities.Category> Categories => Set<Domain.Entities.Category>();
    public DbSet<Domain.Entities.Customer> Customers => Set<Domain.Entities.Customer>();
    public DbSet<Domain.Entities.Favorite> Favorites => Set<Domain.Entities.Favorite>();
    public DbSet<Domain.Entities.DetailFavorite> DetailFavorites => Set<Domain.Entities.DetailFavorite>();
    public DbSet<Domain.Entities.Poll> Polls => Set<Domain.Entities.Poll>();
    public DbSet<Domain.Entities.Product> Products => Set<Domain.Entities.Product>();
    public DbSet<Domain.Entities.QualityProduct> QualityProducts => Set<Domain.Entities.QualityProduct>();
    public DbSet<Domain.Entities.Rate> Rates => Set<Domain.Entities.Rate>();
    public DbSet<Domain.Entities.UnitOfMeasure> UnitOfMeasures => Set<Domain.Entities.UnitOfMeasure>();
    public DbSet<Domain.Entities.TypeIdentification> TypeIdentifications => Set<Domain.Entities.TypeIdentification>();
    public DbSet<Domain.Entities.TypesProduct> TypesProducts => Set<Domain.Entities.TypesProduct>();
    public DbSet<Domain.Entities.CategoryPoll> CategoryPolls => Set<Domain.Entities.CategoryPoll>();
    public DbSet<Domain.Entities.CompanyProduct> CompanyProducts => Set<Domain.Entities.CompanyProduct>();
    public DbSet<Domain.Entities.Membership> Memberships => Set<Domain.Entities.Membership>();
    public DbSet<Domain.Entities.MembershipPeriod> MembershipPeriods => Set<Domain.Entities.MembershipPeriod>();
    public DbSet<Domain.Entities.MembershipBenefit> MembershipBenefits => Set<Domain.Entities.MembershipBenefit>();
    public DbSet<Domain.Entities.Period> Periods => Set<Domain.Entities.Period>();
    public DbSet<Domain.Entities.StateRegion> StateRegions => Set<Domain.Entities.StateRegion>();
    public DbSet<Domain.Entities.CityOrMunicipality> CitiesOrMunicipalities => Set<Domain.Entities.CityOrMunicipality>();



public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
