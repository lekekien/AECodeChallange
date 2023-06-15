using AE.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Application.Extensions
{
    public static class ChangeTrackerExtension
    {
        public static void UpdateAuditProperties(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            var auditEntities = changeTracker
                    .Entries()
                    .Where(e => e.Entity is BaseAuditableEntity && e.State is EntityState.Added or EntityState.Modified);

            var entityEntries = auditEntities.ToList();
            if (entityEntries.Any())
            {
                var currentTime = DateTime.UtcNow;
                var currentUserName = "ADMIN";

                foreach (var entry in entityEntries)
                {
                    if (entry.Entity is BaseAuditableEntity fullEntity)
                    {
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                fullEntity.CreateTime = currentTime;
                                fullEntity.CreateUser = currentUserName;
                                break;
                            case EntityState.Modified:
                                changeTracker.Context.Entry(fullEntity).Property(x => x.CreateUser).IsModified = false;
                                changeTracker.Context.Entry(fullEntity).Property(x => x.CreateTime).IsModified = false;
                                fullEntity.UpdateTime = currentTime;
                                fullEntity.UpdateUser = currentUserName;
                                break;
                        }
                        continue;
                    }
                }
            }
        }
    }
}
