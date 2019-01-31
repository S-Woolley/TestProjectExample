using System.Threading.Tasks;
using ProductApi;
using NUnit.Framework;
using System.Net;

namespace ProductApiTest.Profile
{
    class EditName
    {
        Client ApiUnderTest = new Client();
        object userId;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            ApiUnderTest.SignIn("tester@mydomain.com", "myPassword");
            userId = ApiUnderTest.Profile.GetUser("tester@mydomain.com").Data.UserId;
        }

        [Test]
        public void ValidChange()
        {
            var response = ApiUnderTest.Profile.Edit(userId, new { givenName = "Andrew", surname = "Woolley" });
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Andrew", response.Data.GivenName);
            Assert.AreEqual("woolley", response.Data.Surname);
        }

        [Test]
        public async Task ValidChangeAsync()
        {
            var response = await ApiUnderTest.Profile.EditAsync(userId, new { givenName = "Fred", surname = "Woolley" });
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Fred", response.Data.GivenName);
            Assert.AreEqual("woolley", response.Data.Surname);
        }
    }
}
