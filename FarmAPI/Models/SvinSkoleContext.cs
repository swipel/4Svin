using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FarmAPI.Models
{
    public partial class SvinSkoleContext : DbContext
    {
        public SvinSkoleContext()
        {
        }

        public SvinSkoleContext(DbContextOptions<SvinSkoleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barn> Barn { get; set; }
        public virtual DbSet<Box> Box { get; set; }
        public virtual DbSet<BoxType> BoxType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Farm> Farm { get; set; }
        public virtual DbSet<FeedLog> FeedLog { get; set; }
        public virtual DbSet<FoodLog> FoodLog { get; set; }
        public virtual DbSet<FoodMixType> FoodMixType { get; set; }
        public virtual DbSet<FoodType> FoodType { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<SecurityLevel> SecurityLevel { get; set; }
        public virtual DbSet<Sensor> Sensor { get; set; }
        public virtual DbSet<SensorBox> SensorBox { get; set; }
        public virtual DbSet<SensorSilo> SensorSilo { get; set; }
        public virtual DbSet<SensorType> SensorType { get; set; }
        public virtual DbSet<SensorValue> SensorValue { get; set; }
        public virtual DbSet<Silo> Silo { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserFarm> UserFarm { get; set; }
        public virtual DbSet<Zipcode> Zipcode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=PIETRAS.DK\\PIETRASSQL,52384;database=SvinSkole;user=Svin;pwd=#Evq7=4ejbaNkaxr;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barn>(entity =>
            {
                entity.HasKey(e => new { e.BarnNumber, e.FarmId });

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Barn)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Barn__FarmId__4BAC3F29");
            });

            modelBuilder.Entity<Box>(entity =>
            {
                entity.HasKey(e => new { e.BoxNumber, e.BarnNumber, e.FarmId });

                entity.HasOne(d => d.BoxTypeNavigation)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.BoxType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Box__BoxType__5070F446");

                entity.HasOne(d => d.Barn)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => new { d.BarnNumber, d.FarmId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Box__5165187F");
            });

            modelBuilder.Entity<BoxType>(entity =>
            {
                entity.Property(e => e.BoxTypeId).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FarmName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Farm__CountryCod__3C69FB99");

                entity.HasOne(d => d.ZipCodeNavigation)
                    .WithMany(p => p.Farm)
                    .HasForeignKey(d => d.ZipCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Farm__ZipCode__3B75D760");
            });

            modelBuilder.Entity<FeedLog>(entity =>
            {
                entity.Property(e => e.Logtime)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.FeedLog)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FeedLog__FarmId__3F466844");
            });

            modelBuilder.Entity<FoodLog>(entity =>
            {
                entity.Property(e => e.FoodLogId).ValueGeneratedNever();

                entity.Property(e => e.LogTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Silo)
                    .WithMany(p => p.FoodLog)
                    .HasForeignKey(d => new { d.FarmId, d.SiloNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FoodLog__70DDC3D8");
            });

            modelBuilder.Entity<FoodMixType>(entity =>
            {
                entity.HasOne(d => d.BoxType)
                    .WithMany(p => p.FoodMixType)
                    .HasForeignKey(d => d.BoxTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FoodMixTy__BoxTy__6E01572D");

                entity.HasOne(d => d.FoodType)
                    .WithMany(p => p.FoodMixType)
                    .HasForeignKey(d => d.FoodTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FoodMixTy__FoodT__6D0D32F4");
            });

            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.Property(e => e.FoodType1)
                    .IsRequired()
                    .HasColumnName("FoodType")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ReadTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__FarmId__693CA210");

                entity.HasOne(d => d.Silo)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => new { d.FarmId, d.SiloNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__6A30C649");
            });

            modelBuilder.Entity<SecurityLevel>(entity =>
            {
                entity.HasKey(e => e.SecurityLevel1);

                entity.Property(e => e.SecurityLevel1).HasColumnName("SecurityLevel");
            });

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.Property(e => e.SensorId).ValueGeneratedNever();

                entity.HasOne(d => d.SensorType)
                    .WithMany(p => p.Sensor)
                    .HasForeignKey(d => d.SensorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sensor__SensorTy__5629CD9C");
            });

            modelBuilder.Entity<SensorBox>(entity =>
            {
                entity.HasKey(e => new { e.SensorId, e.BoxNumber, e.BarnNumber, e.FarmId });

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.SensorBox)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SensorBox__Senso__59063A47");

                entity.HasOne(d => d.Box)
                    .WithMany(p => p.SensorBox)
                    .HasForeignKey(d => new { d.BoxNumber, d.BarnNumber, d.FarmId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SensorBox__59FA5E80");
            });

            modelBuilder.Entity<SensorSilo>(entity =>
            {
                entity.HasKey(e => new { e.SensorId, e.FarmId, e.SiloNumber });

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.SensorSilo)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SensorSil__Senso__656C112C");

                entity.HasOne(d => d.Silo)
                    .WithMany(p => p.SensorSilo)
                    .HasForeignKey(d => new { d.FarmId, d.SiloNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SensorSilo__66603565");
            });

            modelBuilder.Entity<SensorType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SensorValue>(entity =>
            {
                entity.Property(e => e.LogTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Sensor)
                    .WithMany(p => p.SensorValue)
                    .HasForeignKey(d => d.SensorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SensorVal__Senso__5CD6CB2B");
            });

            modelBuilder.Entity<Silo>(entity =>
            {
                entity.HasKey(e => new { e.FarmId, e.SiloNumber });

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Silo)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Silo__FarmId__619B8048");

                entity.HasOne(d => d.FoodType)
                    .WithMany(p => p.Silo)
                    .HasForeignKey(d => d.FoodTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Silo__FoodTypeId__628FA481");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.SecurityLevelNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.SecurityLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER__SecurityLe__44FF419A");
            });

            modelBuilder.Entity<UserFarm>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FarmId });

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.UserFarm)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserFarm__FarmId__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFarm)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserFarm__UserId__47DBAE45");
            });

            modelBuilder.Entity<Zipcode>(entity =>
            {
                entity.HasKey(e => e.Zipcode1);

                entity.Property(e => e.Zipcode1).HasColumnName("Zipcode");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
