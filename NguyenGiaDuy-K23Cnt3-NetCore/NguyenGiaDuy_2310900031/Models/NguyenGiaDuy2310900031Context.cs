using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenGiaDuy_2310900031.Models;

public partial class NguyenGiaDuy2310900031Context : DbContext
{
    public NguyenGiaDuy2310900031Context()
    {
    }

    public NguyenGiaDuy2310900031Context(DbContextOptions<NguyenGiaDuy2310900031Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NgdEmployee> NgdEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ANHDUYDEPZAI\\MAY1;Database=NguyenGiaDuy_2310900031;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NgdEmployee>(entity =>
        {
            entity.HasKey(e => e.NgdEmpId).HasName("PK__NgdEmplo__403ACBA6B80F3BF5");

            entity.ToTable("NgdEmployee");

            entity.Property(e => e.NgdEmpId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ngdEmpId");
            entity.Property(e => e.NgdEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("ngdEmpLevel");
            entity.Property(e => e.NgdEmpName)
                .HasMaxLength(100)
                .HasColumnName("ngdEmpName");
            entity.Property(e => e.NgdEmpStartDate).HasColumnName("ngdEmpStartDate");
            entity.Property(e => e.NgdEmpStatus).HasColumnName("ngdEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
