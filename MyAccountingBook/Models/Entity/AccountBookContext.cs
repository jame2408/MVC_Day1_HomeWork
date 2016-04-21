namespace MyAccountingBook.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountBookDbContext : DbContext
    {
        public AccountBookDbContext()
            : base("name=SkillTreeHomeWork")
        {
        }

        public virtual DbSet<AccountBookModels> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
