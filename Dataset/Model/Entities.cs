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
        public virtual DbSet<invoicesold> invoicesolds { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<productsold> productsolds { get; set; }
        public virtual DbSet<rolepermission> rolepermissions { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<stock> stocks { get; set; }
        public virtual DbSet<unit> units { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<user>().ToTable("users");
            modelBuilder.Entity<permission>().ToTable("permissions");
            modelBuilder.Entity<role>().ToTable("roles");
            modelBuilder.Entity<rolepermission>().ToTable("rolepermissions");
            modelBuilder.Entity<product>().ToTable("products");
            modelBuilder.Entity<category>().ToTable("categorys");
            modelBuilder.Entity<productsold>().ToTable("productsolds");
            modelBuilder.Entity<invoicesold>().ToTable("invoicesolds");
            modelBuilder.Entity<stock>().ToTable("stocks");

            modelBuilder.Entity<category>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<invoicesold>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .HasMany(e => e.rolepermissions)
                .WithOptional(e => e.permission)
                .HasForeignKey(e => e.ID_PERMISSION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<product>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.rolepermissions)
                .WithOptional(e => e.role)
                .HasForeignKey(e => e.ID_ROLE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<stock>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<stock>()
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
                .Property(e => e.DESCRIPTION)
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
        }
    }
}
