using System.Threading.Tasks;
using ProductApi;
using NUnit.Framework;
using System.Net;

namespace ProductApiTest.Profile
{
    class EditName
    {
        Client productUnderTest = new Client();
        object userId;

        [OneTimeSetUp]
        public void prepareTestSuite()
        {
            productUnderTest.SignIn("tester@mydomain.com", "myPassword");
            userId = productUnderTest.Profile.GetUser("tester@mydomain.com").Data.userId;
        }

        [Test]
        public void ValidChange()
        {
            var response = productUnderTest.Profile.Edit(userId, new { givenName = "Andrew", surname = "Woolley" });
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Andrew", response.Data.givenName);
            Assert.AreEqual("woolley", response.Data.surname);
        }

        [Test]
        public async Task ValidChangeAsync()
        {
            var response = await productUnderTest.Profile.EditAsync(userId, new { givenName = "Fred", surname = "Woolley" });
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Fred", response.Data.givenName);
            Assert.AreEqual("woolley", response.Data.surname);
        }
    }
}
