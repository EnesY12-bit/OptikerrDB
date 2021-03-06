#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OptikerService.Models
{
    public partial class optikerdbContext : DbContext
    {
        public optikerdbContext()
        {
        }

        public optikerdbContext(DbContextOptions<optikerdbContext> options) : base(options)
        {
        }

        public virtual DbSet<betreut> betreut { get; set; }
        public virtual DbSet<brillen> brillen { get; set; }
        public virtual DbSet<geschaeft> geschaeft { get; set; }
        public virtual DbSet<kauft> kauft { get; set; }
        public virtual DbSet<kunden> kunden { get; set; }
        public virtual DbSet<kunden_brillen> kunden_brillen { get; set; }
        public virtual DbSet<lieferer> lieferer { get; set; }
        public virtual DbSet<liefert> liefert { get; set; }
        public virtual DbSet<mitarbeiter> mitarbeiter { get; set; }
        public virtual DbSet<mitarbeiter_kunden> mitarbeiter_kunden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=optikerdb;User Id=postgres;Password=1903;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<betreut>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.kunden)
                    .WithMany()
                    .HasForeignKey(d => d.kundenid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_betreut_kunden");

                entity.HasOne(d => d.personal)
                    .WithMany()
                    .HasForeignKey(d => d.personalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_betreut_mitarbeiter");
            });

            modelBuilder.Entity<brillen>(entity =>
            {
                entity.HasKey(e => e.modellid)
                    .HasName("brillen_pkey");

                entity.Property(e => e.modellid).ValueGeneratedNever();

                entity.Property(e => e.art)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.glasart)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<geschaeft>(entity =>
            {
                entity.HasKey(e => e.geschaeftsid)
                    .HasName("geschaeft_pkey");

                entity.Property(e => e.geschaeftsid).ValueGeneratedNever();

                entity.Property(e => e.adresse)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.personal)
                    .WithMany(p => p.geschaeft)
                    .HasForeignKey(d => d.personalid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_geschaeft_brillen");
            });

            modelBuilder.Entity<kauft>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.kunden)
                    .WithMany()
                    .HasForeignKey(d => d.kundenid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kauft_kunden");

                entity.HasOne(d => d.modell)
                    .WithMany()
                    .HasForeignKey(d => d.modellid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kauft_brillen");
            });

            modelBuilder.Entity<kunden>(entity =>
            {
                entity.Property(e => e.kundenid).ValueGeneratedNever();

                entity.Property(e => e.adresse)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.anrede)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<kunden_brillen>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("kunden_brillen");

                entity.Property(e => e.brillenname).HasColumnType("character varying");

                entity.Property(e => e.name).HasColumnType("character varying");
            });

            modelBuilder.Entity<lieferer>(entity =>
            {
                entity.HasKey(e => e.lieferid)
                    .HasName("lieferer_pkey");

                entity.Property(e => e.lieferid).ValueGeneratedNever();

                entity.Property(e => e.adresse)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<liefert>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.liefer)
                    .WithMany()
                    .HasForeignKey(d => d.lieferid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liefert_lieferer");

                entity.HasOne(d => d.lieferNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.lieferid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liefert_brillen");
            });

            modelBuilder.Entity<mitarbeiter>(entity =>
            {
                entity.HasKey(e => e.personalid)
                    .HasName("mitarbeiter_pkey");

                entity.Property(e => e.personalid).ValueGeneratedNever();

                entity.Property(e => e.adress)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.anrede)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.taetigkeit)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<mitarbeiter_kunden>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("mitarbeiter_kunden");

                entity.Property(e => e.kundenname).HasColumnType("character varying");

                entity.Property(e => e.name).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}