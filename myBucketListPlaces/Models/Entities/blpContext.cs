using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace myBucketListPlaces.Models.Entities
{
    public partial class blpContext : DbContext
    {
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<User> User { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blpDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageName).IsRequired();

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Image_ToPlace");
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.Property(e => e.Link1)
                    .IsRequired()
                    .HasColumnName("Link");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Link)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Link_ToPlace");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Place)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Place_ToUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}