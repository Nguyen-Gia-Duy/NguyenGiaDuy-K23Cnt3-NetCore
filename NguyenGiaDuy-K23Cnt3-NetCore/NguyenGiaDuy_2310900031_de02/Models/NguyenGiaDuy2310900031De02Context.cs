using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenGiaDuy_2310900031_de02.Models;

public partial class NguyenGiaDuy2310900031De02Context : DbContext
{
    public NguyenGiaDuy2310900031De02Context()
    {
    }

    public NguyenGiaDuy2310900031De02Context(DbContextOptions<NguyenGiaDuy2310900031De02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NgdCatalog> NgdCatalogs { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ANHDUYDEPZAI\\MAY1;Database=NguyenGiaDuy_2310900031_DE02;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NgdCatalog>(entity =>
        {
            entity.HasKey(e => e.NgdCateId);

            entity.ToTable("NgdCatalog");

            entity.Property(e => e.NgdCateId).HasColumnName("ngdCateId");
            entity.Property(e => e.NgdCateActive).HasColumnName("ngdCateActive");
            entity.Property(e => e.NgdCateName)
                .HasMaxLength(100)
                .HasColumnName("ngdCateName");
            entity.Property(e => e.NgdCatePrice)
                .HasMaxLength(100)
                .HasColumnName("ngdCatePrice");
            entity.Property(e => e.NgdCateQty)
                .HasMaxLength(100)
                .HasColumnName("ngdCateQty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
