using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Controllers;
using System.Web.Mvc;

namespace Unit_test
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_CorrectView()
        {
            // ARRANGE
            HomeController controller = new HomeController();

            // ACT
            ActionResult result = controller.Index();

            // ASSERT
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}