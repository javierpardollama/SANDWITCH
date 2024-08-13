using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Contexts.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry @entity in eventData.Context.ChangeTracker.Entries())
            {
                switch (@entity.State)
                {
                    case EntityState.Added:
                        @entity.CurrentValues["LastModified"] = DateTime.Now;
                        @entity.State = EntityState.Added;
                        @entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Modified:
                        @entity.CurrentValues["LastModified"] = DateTime.Now;
                        @entity.State = EntityState.Modified;
                        @entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Deleted:
                        @entity.CurrentValues["LastModified"] = DateTime.Now;
                        @entity.State = EntityState.Modified;
                        @entity.CurrentValues["Deleted"] = true;
                        break;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            foreach (EntityEntry @entity in eventData.Context.ChangeTracker.Entries())
            {
                switch (@entity.State)
                {
                    case EntityState.Added:
                        @entity.CurrentValues["LastModified"] = DateTime.Now;
                        @entity.State = EntityState.Added;
                        @entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Modified:
                        @entity.CurrentValues["LastModified"] = DateTime.Now;
                        @entity.State = EntityState.Modified;
                        @entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Deleted:
                        @entity.CurrentValues["LastModified"] = DateTime.Now;
                        @entity.State = EntityState.Modified;
                        @entity.CurrentValues["Deleted"] = true;
                        break;
                }
            }

            return base.SavingChanges(eventData, result);
        }       
    }
}
