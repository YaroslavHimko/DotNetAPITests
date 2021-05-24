using NUnit.Framework;
using System.Net;

namespace DotNetAPITests.Verifications
{
    public static class VerifyStatusCode
    {
        public static void AreEqual(HttpStatusCode expectedCode, HttpStatusCode actualCode)
        {
            TestContext.WriteLine($"Requested code was {expectedCode}, actual code was {actualCode}");
            Assert.AreEqual(expectedCode, actualCode);
        }
    }
}
