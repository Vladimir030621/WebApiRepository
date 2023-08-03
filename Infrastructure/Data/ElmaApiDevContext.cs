using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class ElmaApiDevContext : DbContext
{
    public ElmaApiDevContext()
    {
    }

    public ElmaApiDevContext(DbContextOptions<ElmaApiDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Currencyrate> Currencyrates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currencyrate>(entity =>
        {
            entity.HasKey(e => e.Currencyrateid).HasName("currencyrates_pkey");

            entity.ToTable("currencyrates");

            entity.Property(e => e.Currencyrateid).HasColumnName("currencyrateid");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .HasColumnName("code");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Purchaserate).HasColumnName("purchaserate");
            entity.Property(e => e.Sellingrate).HasColumnName("sellingrate");
            entity.Property(e => e.Sideid)
                .HasMaxLength(20)
                .HasColumnName("sideid");
            entity.Property(e => e.Toboid)
                .HasMaxLength(20)
                .HasColumnName("toboid");
            entity.Property(e => e.Tobosname)
                .HasColumnType("character varying")
                .HasColumnName("tobosname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
