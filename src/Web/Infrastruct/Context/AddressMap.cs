namespace Infrastruct;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("addresses");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.DisplayName)
            .HasColumnType("nvarchar(512)")
            .HasColumnName("display_name");

        builder.Property(c => c.Latitude)
            .HasColumnName("latitude").HasColumnType("decimal(8, 6)");
        builder.Property(c => c.Longitude)
            .HasColumnName("longitude").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.HouseNumber)
            .HasColumnName("house_number")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.Road)
            .HasColumnName("road")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.Neighbourhood)
            .HasColumnName("neighbourhood")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.City)
            .HasColumnName("city")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.County)
            .HasColumnName("county")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.Postcode)
            .HasColumnName("postcode")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.State)
            .HasColumnName("state")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.StateDistrict)
            .HasColumnName("state_district")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.Country)
            .HasColumnName("country")
            .HasColumnType("nvarchar(255)");

        builder.Property(c => c.Raw)
            // .HasColumnType("nvarchar(max)")
            .HasColumnType("TEXT")
            .HasColumnName("raw");

        builder.Property(c => c.InsertedAt)
            .HasColumnName("inserted_at");

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(c => c.OsmId)
            .HasColumnName("osm_id");

        builder.Property(c => c.OsmType)
            // .HasColumnType("nvarchar(max)")
            .HasColumnType("TEXT")
            .HasColumnName("osm_type");
    }
}