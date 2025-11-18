using App.Controllers;
using Moq;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MSTestAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Unit_test
{
    [TestClass]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void Index_Returns_ErrorView()
        {
            // ARRANGE
            var controller = new ErrorController();

            // ACT
            ActionResult result = controller.Index();

            // ASSERT
            MSTestAssert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            MSTestAssert.AreEqual("Error", viewResult.ViewName);
        }

        [TestMethod]
        public void NotFound_Sets_StatusCode_And_Returns_ErrorView()
        {
            // ARRANGE
            var controller = new ErrorController();

            var httpContextMock = new Mock<HttpContext>();
            var httpResponseMock = new Mock<HttpResponse>();
            httpContextMock.Setup(ctx => ctx.Response).Returns(httpResponseMock.Object);
                      

            // ACT
            ActionResult result = controller.NotFound();

            // ASSERT
            MSTestAssert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            MSTestAssert.AreEqual("Error", viewResult.ViewName);
            httpResponseMock.VerifySet(r => r.StatusCode = 404, Times.Once());
        }
    }
}
