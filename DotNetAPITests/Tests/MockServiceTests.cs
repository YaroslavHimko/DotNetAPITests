using DotNetAPITests.Services;
using DotNetAPITests.Verifications;
using NUnit.Framework;
using System.Net;

namespace DotNetAPITests
{
    [TestFixture]
    public class MockServiceTests
    {
        private MockService _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new MockService();
        }

        [TestCase(HttpStatusCode.Unauthorized)]
        public void Verify_Unauthorized_Response(HttpStatusCode requestedCode)
        {
            var actualCode = _mockService.GetCode(requestedCode).Result.StatusCode;
            VerifyStatusCode.AreEqual(requestedCode, actualCode);
        }

        [TestCase(HttpStatusCode.BadRequest)]
        public void Verify_BadRequest_Response(HttpStatusCode requestedCode)
        {
            var actualCode = _mockService.GetCode(requestedCode).Result.StatusCode;
            VerifyStatusCode.AreEqual(requestedCode, actualCode);
        }

        [TestCase(HttpStatusCode.PaymentRequired)]
        public void Verify_PaymentRequired_Response(HttpStatusCode requestedCode)
        {
            var actualCode = _mockService.GetCode(requestedCode).Result.StatusCode;
            VerifyStatusCode.AreEqual(requestedCode, actualCode);
        }

        [TestCase(HttpStatusCode.Forbidden)]
        public void Verify_Forbidden_Response(HttpStatusCode requestedCode)
        {
            var actualCode = _mockService.GetCode(requestedCode).Result.StatusCode;
            VerifyStatusCode.AreEqual(requestedCode, actualCode);
        }

        [TestCase(HttpStatusCode.NotFound)]
        public void Verify_NotFound_Response(HttpStatusCode requestedCode)
        {
            var actualCode = _mockService.GetCode(requestedCode).Result.StatusCode;
            VerifyStatusCode.AreEqual(requestedCode, actualCode);
        }
    }
}