using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using rjff.avmb.core.Models;

namespace rjff.avmb.infrastructure.Context
{
      public class ApiContext : IdentityDbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }

        public DbSet<CriarEnvelope> CriarEnvelope { get; set; }
        public DbSet<ConfigurarSignatario> ConfigurarSignatario { get; set; }
        public DbSet<EncaminharEnvelopeParaAssinatura> EncaminharEnvelopeParaAssinatura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(260)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        private const string CONST_DATA = "DataCriacao";
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(CONST_DATA) != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(CONST_DATA).CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(CONST_DATA).IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
