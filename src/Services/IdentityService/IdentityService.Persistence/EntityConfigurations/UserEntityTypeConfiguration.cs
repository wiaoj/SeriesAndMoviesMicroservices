using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;
using IdentityService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityService.Persistence.EntityConfigurations;
public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("Users", IdentityDbContext.DEFAULT_SCHEMA);

        ConfigureUsersTable(builder);


        //var @byte = new Byte[10];
        //builder.HasData(new List<User>() {
        //    //User.Create("Bertan1","Tokgöz1","bertan1@gmail.com",@byte,@byte),
        //    //User.Create(Name.Create("Bertan","Tokgöz"), Email.Create("bertan2@gmail.com"), Password.Create(@byte,@byte)),
        //});
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder) {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique(true);
        builder.Property<UserId>(x => x.Id)
               .IsRequired(true)
               .ValueGeneratedNever()
               .HasConversion(
                    userId => userId.Value,
                    value => UserId.Create(value));

        builder.Property<FirstName>(x => x.FirstName)
               .HasConversion(
                    name => name.Value,
                    value => FirstName.Create(value));

        builder.Property<LastName>(x => x.LastName)
               .HasConversion(
                    name => name.Value,
                    value => LastName.Create(value));

        builder.Property<Email>(x => x.Email)
               .IsRequired(true)
               .HasConversion(
                    email => email.Value,
                    value => Email.Create(value));

        builder.HasIndex(x => x.Email, "UK_Users_Email")
               .IsUnique(true);

        builder.Property<PasswordSalt>(x => x.PasswordSalt)
               .IsRequired(true)
               .HasConversion(
                    passwordSalt => passwordSalt.Value,
                    value => PasswordSalt.Create(value));

        builder.Property<PasswordHash>(x => x.PasswordHash)
               .IsRequired(true)
               .HasConversion(
                    passwordSalt => passwordSalt.Value,
                    value => PasswordHash.Create(value));
    }
}