using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FoodtekAPI.Models;

public partial class FoodtekDbContext : DbContext
{
    public FoodtekDbContext()
    {
    }

    public FoodtekDbContext(DbContextOptions<FoodtekDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FavoriteItem> FavoriteItems { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<LookupItem> LookupItems { get; set; }

    public virtual DbSet<LookupType> LookupTypes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrdersTracking> OrdersTrackings { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<RatingsAndReview> RatingsAndReviews { get; set; }

    public virtual DbSet<ReportedIssue> ReportedIssues { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-480GQEA\\SQLEXPRESS01;Initial Catalog=RestaurantDB10;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1B4D16BDA4");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressDetails).HasMaxLength(255);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Gpslocation)
                .HasMaxLength(255)
                .HasColumnName("GPSLocation");
            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Client).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Addresses__Clien__76969D2E");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E88FCA68F2");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.AdminNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admins__AdminID__778AC167");

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admins__RoleID__787EE5A0");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BE7F5A500");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("NameEN");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A04CB33A467");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("ClientID");

            entity.HasOne(d => d.ClientNavigation).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clients__ClientI__797309D9");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.CaptainId).HasName("PK__Deliveri__5DA83913D92255A7");

            entity.Property(e => e.CaptainId)
                .ValueGeneratedNever()
                .HasColumnName("CaptainID");
            entity.Property(e => e.NumOfCompletedDeliveries).HasDefaultValue(0);
            entity.Property(e => e.VehicleTypeId).HasColumnName("VehicleTypeID");

            entity.HasOne(d => d.Captain).WithOne(p => p.Delivery)
                .HasForeignKey<Delivery>(d => d.CaptainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deliverie__Capta__7A672E12");

            entity.HasOne(d => d.VehicleType).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.VehicleTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deliverie__Vehic__7B5B524B");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__E43F6DF6D304B3A7");

            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DescriptionAr)
                .HasMaxLength(255)
                .HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(255)
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TitleAr)
                .HasMaxLength(100)
                .HasColumnName("TitleAR");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(100)
                .HasColumnName("TitleEN");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1930AA515");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.EmployeeNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Emplo__7C4F7684");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__RoleI__7D439ABD");
        });

        modelBuilder.Entity<FavoriteItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__4159F23A42E19F3F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(15)
                .IsFixedLength();

            entity.HasOne(d => d.Client).WithMany(p => p.FavoriteItems)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FavoriteI__Clien__7E37BEF6");

            entity.HasOne(d => d.Item).WithMany(p => p.FavoriteItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FavoriteI__ItemI__7F2BE32F");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E83EB19132383");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ArabicName).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.DescriptionAr)
                .HasMaxLength(255)
                .HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn)
                .HasMaxLength(255)
                .HasColumnName("DescriptionEN");
            entity.Property(e => e.EnglishName).HasMaxLength(100);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StockQuantity).HasDefaultValue(0);

            entity.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Items__CategoryI__00200768");
        });

        modelBuilder.Entity<LookupItem>(entity =>
        {
            entity.HasKey(e => e.LookupItemId).HasName("PK__LookupIt__58C88B2E45A168A3");

            entity.Property(e => e.LookupItemId).HasColumnName("LookupItemID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LookupTypeId).HasColumnName("LookupTypeID");
            entity.Property(e => e.NameAr)
                .HasMaxLength(100)
                .HasColumnName("NameAR");
            entity.Property(e => e.NameEn)
                .HasMaxLength(100)
                .HasColumnName("NameEN");

            entity.HasOne(d => d.LookupType).WithMany(p => p.LookupItems)
                .HasForeignKey(d => d.LookupTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LookupIte__Looku__01142BA1");
        });

        modelBuilder.Entity<LookupType>(entity =>
        {
            entity.HasKey(e => e.LookupTypeId).HasName("PK__LookupTy__15BEA581486F7B4D");

            entity.HasIndex(e => e.LookupTypeName, "UQ__LookupTy__6CA3FC546F68829F").IsUnique();

            entity.Property(e => e.LookupTypeId).HasColumnName("LookupTypeID");
            entity.Property(e => e.LookupTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E321EB14F7B");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Notif__02FC7413");

            entity.HasOne(d => d.Receiver).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__Recei__02084FDA");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF2D1879A9");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AssignedCaptainId).HasColumnName("AssignedCaptainID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DeliveryFee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

            entity.HasOne(d => d.AssignedCaptain).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AssignedCaptainId)
                .HasConstraintName("FK__Orders__Assigned__08B54D69");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__ClientID__05D8E0BE");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("FK__Orders__Discount__06CD04F7");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__OrderSta__07C12930");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__OrderIte__64B7B391FEBAA167");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__ItemI__04E4BC85");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__03F0984C");
        });

        modelBuilder.Entity<OrdersTracking>(entity =>
        {
            entity.HasKey(e => e.TrackingId).HasName("PK__OrdersTr__3C19EDD163390028");

            entity.ToTable("OrdersTracking");

            entity.HasIndex(e => e.OrderId, "UQ__OrdersTr__C3905BAEB3925D9F").IsUnique();

            entity.Property(e => e.TrackingId).HasColumnName("TrackingID");
            entity.Property(e => e.CaptainId).HasColumnName("CaptainID");
            entity.Property(e => e.CurrentStatus).HasMaxLength(100);
            entity.Property(e => e.EstimatedArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedLocation).HasMaxLength(255);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Captain).WithMany(p => p.OrdersTrackings)
                .HasForeignKey(d => d.CaptainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdersTra__Capta__0A9D95DB");

            entity.HasOne(d => d.Order).WithOne(p => p.OrdersTracking)
                .HasForeignKey<OrdersTracking>(d => d.OrderId)
                .HasConstraintName("FK__OrdersTra__Order__09A971A2");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__DC31C1F3924280D4");

            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.CardTypeId).HasColumnName("CardTypeID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.IsDefault).HasDefaultValue(false);
            entity.Property(e => e.Last4Digits).HasMaxLength(4);

            entity.HasOne(d => d.Client).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentMe__Clien__0B91BA14");
        });

        modelBuilder.Entity<RatingsAndReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__RatingsA__74BC79AE60F6FCDC");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CaptainId).HasColumnName("CaptainID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ReviewText).HasMaxLength(500);

            entity.HasOne(d => d.Client).WithMany(p => p.RatingsAndReviews)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RatingsAn__Clien__0C85DE4D");
        });

        modelBuilder.Entity<ReportedIssue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK__Reported__6C8616249589E657");

            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.AdminResponse).HasMaxLength(500);
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IssueTypeId).HasColumnName("IssueTypeID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.ReportedIssues)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReportedI__Clien__0D7A0286");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACE424D627");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B02163B8").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfileImage).HasMaxLength(255);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

            entity.HasOne(d => d.Status).WithMany(p => p.UserStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Status");

            entity.HasOne(d => d.UserType).WithMany(p => p.UserUserTypes)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
