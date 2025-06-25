using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NgdLesson10Db.Models;

public partial class NgdK23cnt3Ls10DbContext : DbContext
{
    public NgdK23cnt3Ls10DbContext()
    {
    }

    public NgdK23cnt3Ls10DbContext(DbContextOptions<NgdK23cnt3Ls10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NgdPost> NgdPosts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ANHDUYDEPZAI\\MAY1;Database=NgdK23CNT3_Ls10_db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NgdPost>(entity =>
        {
            entity.HasKey(e => e.NgdId);

            entity.ToTable("NgdPost");

            entity.Property(e => e.NgdId).HasColumnName("ngdId");
            entity.Property(e => e.NgdContent)
                .HasColumnType("ntext")
                .HasColumnName("ngdContent");
            entity.Property(e => e.NgdImage)
                .HasMaxLength(100)
                .HasColumnName("ngdImage");
            entity.Property(e => e.NgdStatus).HasColumnName("ngdStatus");
            entity.Property(e => e.NgdTitle)
                .HasMaxLength(100)
                .HasColumnName("ngdTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
