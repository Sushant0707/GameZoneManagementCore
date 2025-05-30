using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GameZoneManagement.Models;

public partial class GameZoneContext : DbContext
{
    public GameZoneContext()
    {
    }

    public GameZoneContext(DbContextOptions<GameZoneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<TblGame> TblGames { get; set; }

    public virtual DbSet<TblGameMode> TblGameModes { get; set; }

    public virtual DbSet<TblGameType> TblGameTypes { get; set; }

    public virtual DbSet<TblGameZone> TblGameZones { get; set; }

    public virtual DbSet<TblGameZone1> TblGameZones1 { get; set; }

    public virtual DbSet<TblPlayerRecord> TblPlayerRecords { get; set; }

    public virtual DbSet<ViewGame> ViewGames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {

        }
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server = DESKTOP-1DCA8F9;Database=GameZone;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblGame>(entity =>
        {

            entity.ToTable("tblGames");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.Games).HasMaxLength(50);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Price).HasMaxLength(50);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<TblGameMode>(entity =>
        {
            entity.ToTable("tblGameMode"); 

            entity.HasKey(e => e.ModeId); 

            entity.Property(e => e.GamingMode).HasMaxLength(30);
            entity.Property(e => e.ModeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ModeID");
        });

        modelBuilder.Entity<TblGameType>(entity =>
        {
            entity.ToTable("tblGameType");

            entity.HasKey(e => e.GameTypeId);

            entity.Property(e => e.GameType).HasMaxLength(30);
            entity.Property(e => e.GameTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("GameTypeID");
            entity.Property(e => e.ModeId).HasColumnName("ModeID");
        });

        modelBuilder.Entity<TblGameZone>(entity =>
        {
            entity.ToTable("tblGameZone"); // ✅ Move this to the top

            entity.HasKey(e => e.UserId); // ✅ Primary key

            entity.Property(e => e.UserCity).HasMaxLength(50);
            entity.Property(e => e.UserConfirmPassword).HasMaxLength(50);
            entity.Property(e => e.UserEmail).HasMaxLength(50);
            entity.Property(e => e.UserGender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UserState).HasMaxLength(50);
            entity.Property(e => e.UserType).HasMaxLength(10);
        });

        modelBuilder.Entity<TblGameZone1>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("TblGameZones");
        });

        modelBuilder.Entity<TblPlayerRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblPlayerRecord");

            entity.Property(e => e.BookingId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BookingID");
            entity.Property(e => e.Discount).HasMaxLength(50);
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.Games).HasMaxLength(50);
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.PlayerName).HasMaxLength(50);
            entity.Property(e => e.Price).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewGame>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_game");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.Expr1).HasMaxLength(50);
            entity.Property(e => e.GameType).HasMaxLength(30);
            entity.Property(e => e.Games).HasMaxLength(50);
            entity.Property(e => e.PlayerName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
