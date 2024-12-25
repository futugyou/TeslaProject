namespace Infrastruct;

public class VehicleMessageMap : IEntityTypeConfiguration<VehicleMessage>
{
    public void Configure(EntityTypeBuilder<VehicleMessage> builder)
    {
        builder.ToTable("socket_datas");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.UserID)
            .HasColumnType("nvarchar(512)")
            .HasColumnName("user_id");

        builder.Property(c => c.VinID)
            .HasColumnName("vin_id");

        builder.Property(c => c.Vin)
            .HasColumnName("vin");

        builder.Property(c => c.Raw)
            // .HasColumnType("nvarchar(max)")
            .HasColumnType("TEXT")
            .HasColumnName("raw");

        builder.Property(c => c.IsHandled)
            .HasColumnName("is_handled");

        builder.Property(c => c.InsertedAt)
            .HasColumnName("inserted_at");
    }
}