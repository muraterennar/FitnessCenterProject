using Core.Entities.Concreate;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework
{
    public class FitnessCenterContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NIRVANA;Database = FitnessCenter;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<SalarySubscription> SalarySubscriptions { get; set; }
        public DbSet<SemiannualSubscription> SemiannualSubscriptions { get; set; }
        public DbSet<AnnualSubscription> AnnualSubscriptions { get; set; }
    }
}
