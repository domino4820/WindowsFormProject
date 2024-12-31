using Microsoft.EntityFrameworkCore;
using LauncherGames.DAL.Models;

namespace LauncherGames.DAL.Context
{
    public class LauncherGamesContext : DbContext
    {
        public LauncherGamesContext(DbContextOptions<LauncherGamesContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGameDetail> UserGameDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình cho User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.Username).IsUnique();
            });

            // Cấu hình cho Game
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);
                entity.Property(e => e.GameName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).HasMaxLength(2000).IsRequired(false);
                entity.Property(e => e.GameImage).IsRequired(false);
                entity.Property(e => e.CreatedAt).IsRequired(false);
                entity.Property(e => e.DownloadPath).IsRequired(false);
                entity.Property(e => e.RunPath).IsRequired(false);
            });

            // Cấu hình cho UserGameDetail
            modelBuilder.Entity<UserGameDetail>(entity =>
            {
                entity.HasKey(e => e.UserGameId);
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserGameDetails)
                    .HasForeignKey(d => d.UserId);
                entity.HasOne(d => d.Game)
                    .WithMany(p => p.UserGameDetails)
                    .HasForeignKey(d => d.GameId);
            });

            // Cấu hình cho Transaction
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.AmountInVND).HasColumnType("decimal(18,2)");
            });

            // Cấu hình cho Feedback
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FeedbackId);
            });

        }
    }
}