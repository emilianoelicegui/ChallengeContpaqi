using System;
using System.Collections.Generic;
using Contpaqi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Contpaqi.Data.Contexts;

public partial class ContpaqiDbContext : DbContext
{
    public ContpaqiDbContext()
    {
    }

    public ContpaqiDbContext(DbContextOptions<ContpaqiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6MQF69Q\\SQLEXPRESS;Initial Catalog=Contpaqi; User Id=eelicegui;Password=123456;TrustServerCertificate=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07CF753A12");

            entity.ToTable("Employee");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.CivilStatus).HasMaxLength(20);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Rfc).HasMaxLength(13);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
