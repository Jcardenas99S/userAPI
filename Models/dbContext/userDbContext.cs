using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace usersAPI.Models.dbContext;

public partial class userDbContext : DbContext
{
    public userDbContext()
    {
    }

    public userDbContext(DbContextOptions<userDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3BB2B957");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserInfoId).HasName("PK__UserInfo__D07EF2C4CC939853");

            entity.ToTable("UserInfo", tb => tb.HasTrigger("UpdateUsernameTrigger"));

            entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

            entity.HasOne(d => d.User).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserInfo_UserID");

            entity.HasOne(d => d.UserRole).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK_UserInfo_UserRoleID");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A35F3C308A7");

            entity.ToTable("UserRole");

            entity.HasIndex(e => e.RoleCoddeType, "UQ__UserRole__F78F5C13D2F82578").IsUnique();

            entity.Property(e => e.UserRoleId).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.RoleCoddeType).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
