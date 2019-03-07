namespace Data_Access.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebModelDbContext : DbContext
    {
        public WebModelDbContext()
            : base("name=WebModelDbContext")
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<New> New { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
