//using IdentityService.Domain.RefreshTokens;
//using IdentityService.Persistence.Context;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System.Security.Cryptography.X509Certificates;

//namespace IdentityService.Persistence.EntityConfigurations;
//public class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshToken> {
//    public void Configure(EntityTypeBuilder<RefreshToken> builder) {
//        builder.ToTable("RefreshTokens", IdentityDbContext.DEFAULT_SCHEMA);

//        builder.HasKey(x => x.Id);
//        builder.HasIndex(x => x.Id).IsUnique(true);
//        builder.Property(x => x.Id)
//               .IsRequired(true)
//               .HasConversion(refreshTokenId => refreshTokenId.Value, id => id)
//               .ValueGeneratedNever();

//        builder.Property(x => x.UserId)
//               .IsRequired(true);

//        builder.Property(x => x.Expires)
//               .IsRequired(true);

//        //builder.HasIndex(x => x.Created);
//        builder.Property(x => x.Created)
//               .IsRequired(true);

//        builder.Property(x => x.CreatedByIp)
//               .IsRequired(true);

//        builder.Property(x => x.Revoked)
//               .IsRequired(default);

//        builder.Property(x => x.RevokedByIp)
//               .IsRequired(default);

//        builder.Property(x => x.ReplacedByToken)
//               .IsRequired(default);

//        builder.Property(x => x.ReasonRevoked)
//               .IsRequired(default);

//        builder.HasOne(x => x.User);
//    }
//}