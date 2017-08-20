using ProductApi;
using RestSharp;
using NUnit.Framework;
using System.Net;

namespace ProductApiTest.Authentication
{
    class SignIn
    {
        Client apiUnderTest = new Client();

        [Test]
        public void InvalidPassword()
        {
            IRestResponse response= apiUnderTest.SignIn("tester@mydomain.com", "no");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.IsNull(apiUnderTest.Cookies["myAuthenticatedCookie"]);
        }

        [Test]
        public void InvalidType()
        {
            IRestResponse response = apiUnderTest.SignIn("tester@mydomain.com", "myPassword");
            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
            Assert.IsNotNull(apiUnderTest.Cookies["myAuthenticatedCookie"]);
        }

    }
}
