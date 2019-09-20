using Microsoft.EntityFrameworkCore;
using Shared.Core.DI;
using Shared.Core.EF.Extensions;
using Shared.Core.Security;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Core.EF
{
    public abstract class DbContextBase : DbContext
    {
        public bool IsInMemory { get { return Database.IsInMemory(); } }
        protected DbContextBase(DbContextOptions options) : base(options)
        {
            Database.AutoTransactionsEnabled = true;
        }

        protected abstract string DefaultSchema { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            //OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete)
                {
                    entry.State = EntityState.Modified;
                    ((ISoftDelete)entry.Entity).DeletedDate = DateTime.UtcNow;
                    ((ISoftDelete)entry.Entity).IsDeleted = true;
                }

                var userId = IoC.Instance.Resolve<IPrincipalContext>()?.UserId;
                if (entry.State == EntityState.Added && entry.Entity is ICreate)
                {
                    ((ICreate)entry.Entity).CreatedDate = DateTime.UtcNow;
                    ((ICreate)entry.Entity).CreatedUserId = userId ?? 1;
                }

                if (entry.State == EntityState.Modified && entry.Entity is IModify)
                {
                    ((IModify)entry.Entity).ModifiedDate = DateTime.UtcNow;
                    ((IModify)entry.Entity).ModifiedUserId = userId;
                }
            }
        }
    }
}
