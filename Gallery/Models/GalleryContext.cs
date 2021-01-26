using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gallery.Models
{
    public partial class GalleryContext : DbContext
    {
        public GalleryContext()
        {
        }

        public GalleryContext(DbContextOptions<GalleryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtWork> ArtWorks { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupArtist> GroupArtists { get; set; }
        public virtual DbSet<GroupArtwork> GroupArtworks { get; set; }
        public virtual DbSet<UserArtWork> UserArtWorks { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\LOCAL;Database=Gallery;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<ArtWork>(entity =>
            {
                entity.HasKey(e => e.Awid)
                    .HasName("PK__ArtWork__07CE6A4C6FB8AC4A");

                entity.ToTable("ArtWork");

                entity.Property(e => e.Awid).HasColumnName("AWID");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Awdate)
                    .HasColumnType("date")
                    .HasColumnName("AWDate");

                entity.Property(e => e.Awinformation)
                    .HasMaxLength(150)
                    .HasColumnName("AWInformation");

                entity.Property(e => e.Awname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AWName");

                entity.Property(e => e.Awtype)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AWType");

                entity.Property(e => e.Awvalue)
                    .HasColumnType("money")
                    .HasColumnName("AWValue");

                entity.HasOne(d => d.AidNavigation)
                    .WithMany(p => p.ArtWorks)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("FK_ArtWork_Artist");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Artist__C69007C8D7FEE056");

                entity.ToTable("Artist");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.Property(e => e.Aborn)
                    .HasColumnType("date")
                    .HasColumnName("ABorn");

                entity.Property(e => e.Adied)
                    .HasColumnType("date")
                    .HasColumnName("ADied");

                entity.Property(e => e.Ainformation)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("AInformation");

                entity.Property(e => e.Aname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AName");

                entity.Property(e => e.AnumberOfWork).HasColumnName("ANumberOfWork");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("PK__Group__6388BCC5FBBDD7DA");

                entity.ToTable("Group");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.Ginfo)
                    .HasMaxLength(500)
                    .HasColumnName("GInfo");

                entity.Property(e => e.Gname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("GName");
            });

            modelBuilder.Entity<GroupArtist>(entity =>
            {
                entity.HasKey(e => new { e.Gid, e.Aid });

                entity.ToTable("Group_Artist");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.Property(e => e.Aid).HasColumnName("AID");

                entity.HasOne(d => d.AidNavigation)
                    .WithMany(p => p.GroupArtists)
                    .HasForeignKey(d => d.Aid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Artist_Artist");

                entity.HasOne(d => d.GidNavigation)
                    .WithMany(p => p.GroupArtists)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Artist_Group");
            });

            modelBuilder.Entity<GroupArtwork>(entity =>
            {
                entity.HasKey(e => new { e.Awid, e.Gid });

                entity.ToTable("Group_Artwork");

                entity.Property(e => e.Awid).HasColumnName("AWID");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.HasOne(d => d.Aw)
                    .WithMany(p => p.GroupArtworks)
                    .HasForeignKey(d => d.Awid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Artwork_ArtWork");

                entity.HasOne(d => d.GidNavigation)
                    .WithMany(p => p.GroupArtworks)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Artwork_Group");
            });

            modelBuilder.Entity<UserArtWork>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("User_ArtWork");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("UID");

                entity.Property(e => e.Awid).HasColumnName("AWID");
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__UserInfo__C5B196027CF280E3");

                entity.ToTable("UserInformation");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Uage).HasColumnName("UAge");

                entity.Property(e => e.Umail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("UMail");

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("UName");

                entity.Property(e => e.Uprofession)
                    .HasMaxLength(50)
                    .HasColumnName("UProfession");

                entity.Property(e => e.Urole)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("URole");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("UserLogin");

                entity.HasIndex(e => e.Username, "IX_UserLogin")
                    .IsUnique();

                entity.Property(e => e.LoginId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LoginID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Login)
                    .WithOne(p => p.UserLogin)
                    .HasForeignKey<UserLogin>(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_UserInformation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
