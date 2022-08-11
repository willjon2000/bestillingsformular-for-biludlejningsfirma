using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class h3_biludlejningContext : DbContext
    {
        public h3_biludlejningContext()
        {
        }

        public h3_biludlejningContext(DbContextOptions<h3_biludlejningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingsAddon> BookingsAddons { get; set; } = null!;
        public virtual DbSet<BookingsAddonsRelation> BookingsAddonsRelations { get; set; } = null!;
        public virtual DbSet<BookingsContact> BookingsContacts { get; set; } = null!;
        public virtual DbSet<BookingsVehicle> BookingsVehicles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=185.252.232.25;user=h3_biludlejning;password=F2FFXx25DD5A8EjT;database=h3_biludlejning", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasIndex(e => e.BookingContactId, "booking_contact_id");

                entity.HasIndex(e => e.BookingVehicleId, "booking_vehicle_id");

                entity.Property(e => e.BookingId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("booking_id");

                entity.Property(e => e.BookingContactId)
                    .HasColumnType("int(11)")
                    .HasColumnName("booking_contact_id");

                entity.Property(e => e.BookingTimestampEnd)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("booking_timestamp_end")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.BookingTimestampStart)
                    .HasColumnType("timestamp")
                    .HasColumnName("booking_timestamp_start")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.BookingVehicleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("booking_vehicle_id");

                entity.HasOne(d => d.BookingContact)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookings_ibfk_1");

                entity.HasOne(d => d.BookingVehicle)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BookingVehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookings_ibfk_2");
            });

            modelBuilder.Entity<BookingsAddon>(entity =>
            {
                entity.HasKey(e => e.BookingAddonId)
                    .HasName("PRIMARY");

                entity.ToTable("Bookings_Addons");

                entity.Property(e => e.BookingAddonId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("booking_addon_id");

                entity.Property(e => e.BookingAddon)
                    .HasMaxLength(32)
                    .HasColumnName("booking_addon");

                entity.Property(e => e.BookingAddonPrice)
                    .HasColumnType("double(10,2)")
                    .HasColumnName("booking_addon_price");
            });

            modelBuilder.Entity<BookingsAddonsRelation>(entity =>
            {
                entity.HasKey(e => e.BookingAddonRelationId)
                    .HasName("PRIMARY");

                entity.ToTable("Bookings_Addons_Relations");

                entity.HasIndex(e => e.BookingAddonId, "booking_addon_id");

                entity.HasIndex(e => e.BookingId, "booking_id");

                entity.Property(e => e.BookingAddonRelationId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("booking_addon_relation_id");

                entity.Property(e => e.BookingAddonId)
                    .HasColumnType("int(11)")
                    .HasColumnName("booking_addon_id");

                entity.Property(e => e.BookingId)
                    .HasColumnType("int(11)")
                    .HasColumnName("booking_id");

                entity.HasOne(d => d.BookingAddon)
                    .WithMany(p => p.BookingsAddonsRelations)
                    .HasForeignKey(d => d.BookingAddonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookings_Addons_Relations_ibfk_1");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingsAddonsRelations)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookings_Addons_Relations_ibfk_2");
            });

            modelBuilder.Entity<BookingsContact>(entity =>
            {
                entity.HasKey(e => e.BookingContactId)
                    .HasName("PRIMARY");

                entity.ToTable("Bookings_Contacts");

                entity.Property(e => e.BookingContactId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("booking_contact_id");

                entity.Property(e => e.BookingContactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("booking_contact_email");

                entity.Property(e => e.BookingContactFullname)
                    .HasMaxLength(255)
                    .HasColumnName("booking_contact_fullname");

                entity.Property(e => e.BookingContactPhone)
                    .HasColumnType("int(8)")
                    .HasColumnName("booking_contact_phone");
            });

            modelBuilder.Entity<BookingsVehicle>(entity =>
            {
                entity.HasKey(e => e.BookingVehicleId)
                    .HasName("PRIMARY");

                entity.ToTable("Bookings_Vehicles");

                entity.Property(e => e.BookingVehicleId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("booking_vehicle_id");

                entity.Property(e => e.BookingVehicle)
                    .HasMaxLength(32)
                    .HasColumnName("booking_vehicle");

                entity.Property(e => e.BookingVehiclePrice)
                    .HasColumnType("double(10,2)")
                    .HasColumnName("booking_vehicle_price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserFullname)
                    .HasMaxLength(255)
                    .HasColumnName("user_fullname");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
