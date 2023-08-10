using Microsoft.EntityFrameworkCore;

namespace DBFirstProductsApp.Entities;

public partial class DiamondPickDbContext : DbContext
{
    public DiamondPickDbContext()
    {
    }

    public DiamondPickDbContext(DbContextOptions<DiamondPickDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catagory> Catagories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DiamondPickDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Fluent API Syntax
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");

            entity.HasOne(d => d.Person).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CatagoryId, "IX_Products_CatagoryId");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.Catagory).WithMany(p => p.Products).HasForeignKey(d => d.CatagoryId);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");

            entity.HasOne(d => d.Person).WithOne(p => p.Supplier)
                .HasForeignKey<Supplier>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });


        //modelBuilder.Entity<Product>().Property("ProductName").HasMaxLength(50);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
