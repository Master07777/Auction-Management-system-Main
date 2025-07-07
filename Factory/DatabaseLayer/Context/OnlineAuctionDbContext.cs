using System;
using System.Collections.Generic;
using Factory.DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Factory.DatabaseLayer.Context;

public partial class OnlineAuctionDbContext : DbContext
{
    public OnlineAuctionDbContext()
    {
    }

    public OnlineAuctionDbContext(DbContextOptions<OnlineAuctionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Settlement> Settlements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LTIN605079;Initial Catalog=OnlineAuctionSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.AuctionId).HasName("PK__Auction__67236DD8AC6F178D");

            entity.ToTable("Auction");

            entity.Property(e => e.AuctionId).HasColumnName("Auction_Id");
            entity.Property(e => e.CurrentBid).HasColumnName("Current_Bid");
            entity.Property(e => e.EndDateTime)
                .HasColumnType("datetime")
                .HasColumnName("End_DateTime");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.StartDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_DateTime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Auction__Product__4222D4EF");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__6DB38D6E13B93D74");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__9834FBBA41087315");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.BasePrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Base_Price");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.ExpectedPrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Expected_Price");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SellerId).HasColumnName("Seller_Id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__4316F928");

            entity.HasOne(d => d.Seller).WithMany(p => p.Products)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Products__Seller__440B1D61");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__F85DA78B77632963");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("Review_Id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__User_Id__44FF419A");
        });

        modelBuilder.Entity<Settlement>(entity =>
        {
            entity.HasKey(e => e.SettlementId).HasName("PK__Settleme__471489DD2A3F1A22");

           

            entity.ToTable("Settlement");

            entity.Property(e => e.SettlementId).HasColumnName("Settlement_Id");
            entity.Property(e => e.AuctionId).HasColumnName("Auction_Id");
            entity.Property(e => e.BuyerId).HasColumnName("Buyer_Id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time");
            entity.Property(e => e.NumberOfDaysOfSettlement).HasColumnName("Number_Of_Days_Of_Settlement");
            entity.Property(e => e.RemainingMoney).HasColumnName("Remaining_Money");
            entity.Property(e => e.SellerId).HasColumnName("Seller_Id");
            entity.Property(e => e.SettlementStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Settlement_Status");

            entity.HasOne(d => d.Auction).WithMany(p => p.Settlements)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Settlemen__Aucti__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206D917035690F8E");
            entity.ToTable("User");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E3800D65BEF").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105346A066E11").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
