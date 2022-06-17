using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TestApp.Models
{
    public partial class youshallpassContext : DbContext
    {
        public youshallpassContext()
        {
        }

        public youshallpassContext(DbContextOptions<youshallpassContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerScoreDetail> PlayerScoreDetails { get; set; }

        public virtual DbSet<Scoreboard> Scoreboard { get; set; }
        public virtual DbSet<SimplePlayer> SimplePlayer { get; set; }
        public virtual DbSet<PlayerScore> PlayerScore { get; set; }
        public virtual DbSet<GameScore> GameScore { get; set; }
        public virtual DbSet<Score> Score { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=youshallpass;User Id=postgres;Password=unico2002;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bitacora");

                entity.Property(e => e.Ids).HasColumnName("ids");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.Operation)
                    .HasMaxLength(1)
                    .HasColumnName("operation");

                entity.Property(e => e.TimeLog).HasColumnName("time_log");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.GameDate)
                    .HasColumnType("date")
                    .HasColumnName("game_date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("player_id");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_player_id");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("register_date")
                    .HasDefaultValueSql("CURRENT_DATE");
            });

            modelBuilder.Entity<PlayerScoreDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("player_score_details");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.Score).HasColumnName("score");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
