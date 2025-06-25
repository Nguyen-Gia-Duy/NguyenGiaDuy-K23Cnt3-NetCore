using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NgdLesson10bai1.Models;

public partial class NgdLesson10Bai1Context : DbContext
{
    public NgdLesson10Bai1Context()
    {
    }

    public NgdLesson10Bai1Context(DbContextOptions<NgdLesson10Bai1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ANHDUYDEPZAI\\MAY1;Database=Ngd_lesson10_bai1;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("Category");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CateName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
