using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace scaffold;

public partial class SvoiContext : DbContext
{
    public SvoiContext()
    {
    }

    public SvoiContext(DbContextOptions<SvoiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Pin> Pins { get; set; }

    public virtual DbSet<PinsShared> PinsShareds { get; set; }

    public virtual DbSet<Relation> Relations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ROTATICK;Initial Catalog=svoi;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasIndex(e => e.UserIdReceiver, "IX_Friends_user_id_receiver");

            entity.HasIndex(e => e.UserIdRequester, "IX_Friends_user_id_requester");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserIdReceiver).HasColumnName("user_id_receiver");
            entity.Property(e => e.UserIdRequester).HasColumnName("user_id_requester");
            entity.Property(e => e.СreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("сreated_at");

            entity.HasOne(d => d.UserIdReceiverNavigation).WithMany(p => p.FriendUserIdReceiverNavigations)
                .HasForeignKey(d => d.UserIdReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UserIdRequesterNavigation).WithMany(p => p.FriendUserIdRequesterNavigations).HasForeignKey(d => d.UserIdRequester);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasIndex(e => e.OwnerUserId, "IX_Groups_owner_user_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");
            entity.Property(e => e.OwnerUserId).HasColumnName("owner_user_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.СreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("сreated_at");

            entity.HasOne(d => d.OwnerUser).WithMany(p => p.Groups).HasForeignKey(d => d.OwnerUserId);
        });

        modelBuilder.Entity<Pin>(entity =>
        {
            entity.HasIndex(e => e.OwnerUserId, "IX_Pins_owner_user_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Lat)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("lat");
            entity.Property(e => e.Lon)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("lon");
            entity.Property(e => e.OwnerUserId).HasColumnName("owner_user_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.СreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("сreated_at");

            entity.HasOne(d => d.OwnerUser).WithMany(p => p.Pins).HasForeignKey(d => d.OwnerUserId);
        });

        modelBuilder.Entity<PinsShared>(entity =>
        {
            entity.ToTable("Pins_shared");

            entity.HasIndex(e => e.PinId, "IX_Pins_shared_pin_id");

            entity.HasIndex(e => e.UserId, "IX_Pins_shared_user_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PinId).HasColumnName("pin_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.СreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("сreated_at");

            entity.HasOne(d => d.Pin).WithMany(p => p.PinsShareds).HasForeignKey(d => d.PinId);

            entity.HasOne(d => d.User).WithMany(p => p.PinsShareds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Relation>(entity =>
        {
            entity.HasIndex(e => e.GroupId, "IX_Relations_group_id");

            entity.HasIndex(e => e.UserId, "IX_Relations_user_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.СreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("сreated_at");

            entity.HasOne(d => d.Group).WithMany(p => p.Relations).HasForeignKey(d => d.GroupId);

            entity.HasOne(d => d.User).WithMany(p => p.Relations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IsRestricted).HasColumnName("is_restricted");
            entity.Property(e => e.IsVerified).HasColumnName("is_verified");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .HasColumnName("username");
            entity.Property(e => e.СreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("сreated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
