using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Data;

public partial class VseRoss2DbContext : DbContext
{
    public VseRoss2DbContext()
    {
    }

    public VseRoss2DbContext(DbContextOptions<VseRoss2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Modem> Modems { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInStorage> ProductInStorages { get; set; }

    public virtual DbSet<ProductInVending> ProductInVendings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<TypeStorage> TypeStorages { get; set; }

    public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vending> Vendings { get; set; }

    public virtual DbSet<VendingType> VendingTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;Database=VseRoss2DB;User Id=sa;Password=1234;Encrypt=False;Trusted_connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contacts)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.InverseCompanyNavigation)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Company_Company");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.ToTable("Mark");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.ToTable("Model");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Mark).WithMany(p => p.Models)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("FK_Model_Mark");
        });

        modelBuilder.Entity<Modem>(entity =>
        {
            entity.ToTable("Modem");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Unit).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_Product_UnitOfMeasurement");
        });

        modelBuilder.Entity<ProductInStorage>(entity =>
        {
            entity.ToTable("ProductInStorage");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInStorages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInStorage_Product");

            entity.HasOne(d => d.Storage).WithMany(p => p.ProductInStorages)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInStorage_Storage");
        });

        modelBuilder.Entity<ProductInVending>(entity =>
        {
            entity.ToTable("ProductInVending");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductInVendings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInVending_Product");

            entity.HasOne(d => d.Vending).WithMany(p => p.ProductInVendings)
                .HasForeignKey(d => d.VendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInVending_Vending");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.DatetimeSale).HasColumnType("datetime");

            entity.HasOne(d => d.Payment).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_PaymentType");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Product");

            entity.HasOne(d => d.Vending).WithMany(p => p.Sales)
                .HasForeignKey(d => d.VendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Vending");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.DateService).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionError)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Services)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_User");

            entity.HasOne(d => d.Vending).WithMany(p => p.Services)
                .HasForeignKey(d => d.VendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_Vending");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.ToTable("Storage");

            entity.HasOne(d => d.TypeStorage).WithMany(p => p.Storages)
                .HasForeignKey(d => d.TypeStorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Storage_TypeStorage");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("Type");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TypeStorage>(entity =>
        {
            entity.ToTable("TypeStorage");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UnitOfMeasurement>(entity =>
        {
            entity.ToTable("UnitOfMeasurement");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vending>(entity =>
        {
            entity.ToTable("Vending");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateInstall).HasColumnType("datetime");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vending_Company");

            entity.HasOne(d => d.Model).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vending_Model");

            entity.HasOne(d => d.Modem).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.ModemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vending_Modem");

            entity.HasOne(d => d.Status).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vending_Status");

            entity.HasOne(d => d.Type).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vending_Type");
        });

        modelBuilder.Entity<VendingType>(entity =>
        {
            entity.ToTable("VendingType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
