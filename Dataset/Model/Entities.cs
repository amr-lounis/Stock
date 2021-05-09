using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Stock.Dataset.Model
{
    public partial class Entities : DbContext
    {
        public virtual DbSet<category> categorys { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<roles_permissions> roles_permissions { get; set; }
        public virtual DbSet<sold_products> sold_products { get; set; }
        public virtual DbSet<unit> units { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<user>().ToTable("users");
            modelBuilder.Entity<unit>().ToTable("units");
            modelBuilder.Entity<sold_products>().ToTable("sold_products");
            modelBuilder.Entity<roles_permissions>().ToTable("roles_permissions");
            modelBuilder.Entity<product>().ToTable("products");
            modelBuilder.Entity<permission>().ToTable("permissions");
            modelBuilder.Entity<invoice>().ToTable("invoices");
            modelBuilder.Entity<category>().ToTable("categorys");

            modelBuilder.Entity<category>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<unit>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<unit>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ACTIVITY)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.NRC)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.NIF)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.FAX)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.WEBSITE)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);
        }
    }
}
