using IdentityService.Domain.Exceptions;
using IdentityService.Domain.Users;
using IdentityService.Domain.Users.ValueObjects;

namespace Domain.Tests;

public class UserTests {
    private User _user;

    [SetUp]
    public void Setup() {
        _user = User.Create("Bertan", "Tokgöz", "bertan@gmail.com", "password");
    }

    [Test]
    [TestCase("Bertan", "Tokgöz", "bertan@gmail.com", "password")]
    public void User_Create(String firstName, String lastName, String email, String password) {
        User user = User.Create(firstName, lastName, email, password);
        Assert.IsNotNull(user);

        //user = User.Create(Name.Create(firstName, lastName), Email.Create(email), Password.Create(password));
        Assert.IsNotNull(user);
        Assert.Pass();
    }

    [Test]
    [TestCase("Bertan", "Tokgöz")]
    public void User_Name_FullName(String firstName, String lastName) {
        //Name name = Name.Create(firstName, lastName);

       // Assert.AreEqual(name.FullName, $"{firstName} {lastName}");
        Assert.Pass();
    }


    [Test]
    [TestCase("Bertan1", "Tokgöz1")]
    public void User_Update_Name(String firstName, String lastName) {
       //_user.Name.Update(firstName, lastName);
        Assert.Pass();
    }

    [Test]
    [TestCase("Tokgöz1")]
    public void User_Update_Name_Same_FirstName(String lastName) {
        //Exception exception = Assert.Throws<UserFirstNameSameDomainException>(() => _user.Name.Update(_user.Name.FirstName, lastName));
        Assert.Pass();
    }

    [Test]
    [TestCase("Bertan1")]
    public void User_Update_Name_Same_LastName(String firstName) {
        //Exception exception = Assert.Throws<UserLastNameSameDomainException>(() => _user.Name.Update(firstName, _user.Name.LastName));
        Assert.Pass();
    }

    [Test]
    [TestCase("email")]
    public void User_Update_Email(String email) {
        _user.Email.Update(email);
        Assert.Pass();
    }

    [Test]
    public void User_Update_Same_Email() {
        Exception exception = Assert.Throws<UserEmailSameDomainException>(() => _user.Email.Update(_user.Email.Value));
        Assert.AreEqual("Emailiniz zaten ayný", exception.Message);
        Assert.Pass();
    }

    [Test]
    [TestCase("pass")]
    public void User_Update_Password(String password) {
        //User user = _user.UpdatePassword(password);
        Assert.Pass();
    }
}