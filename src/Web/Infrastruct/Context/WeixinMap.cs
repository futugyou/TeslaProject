using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class WeixinMap : IEntityTypeConfiguration<Weixin>
{
    public void Configure(EntityTypeBuilder<Weixin> builder)
    {
        builder.HasKey(c => c.Openid);
        builder.Property(c => c.Openid)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("open_id");

        builder.Property(c => c.AppId)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("app_id");

        builder.Property(c => c.UnionId)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("union_id");

        builder.Property(c => c.FromOpenid)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("from_open_id");

        builder.Property(c => c.FromAppId)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("from_app_id");

        builder.Property(c => c.CouldEnv)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("could_env");

        builder.Property(c => c.Source)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("source");

        builder.Property(c => c.Forwarded)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("x-forwarded-for");

        builder.Property(c => c.FromUnionId)
            .HasColumnType("nvarchar(100)")
            .HasColumnName("from_union_id");

    }
}