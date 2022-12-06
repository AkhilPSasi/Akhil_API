using System;
using System.Collections.Generic;
using System.Configuration;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;

namespace Akhil_API.Models;

public partial class CoreDbContext : DbContext
{
    string sqlConnectionString;
    public CoreDbContext()
    {
    }
    public CoreDbContext(DbContextOptions<CoreDbContext> options, IConfiguration config)
        : base(options)
    {
        var secretsClients = new SecretClient(new Uri(config["KeyVaultUrl"]), new DefaultAzureCredential());
        sqlConnectionString = secretsClients.GetSecret("ConnectionString").Value.Value;
    }
    public virtual DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(sqlConnectionString);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
