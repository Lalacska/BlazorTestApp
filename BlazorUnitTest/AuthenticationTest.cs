using System.Security.Cryptography.X509Certificates;
using BlazorTestApp.Components.Pages;
using Bunit;
using Bunit.TestDoubles;
using Xunit;

namespace BlazorUnitTest
{
    public class AuthenticationTest
    {
        [Fact]
        public void LoginViewTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<h2>You are logged in</h2>\r\n        <button>Create File</button>");

        }

        [Fact]
        public void NotLoginViewTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            // Act
            var cut = ctx.RenderComponent<Home>();

            // Assert
            cut.MarkupMatches("<h2>You are not logged in</h2>");

        }


        [Fact]
        public void LoginCodeTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");

            // Act
            var cut = ctx.RenderComponent<Home>();
            var myInstance = cut.Instance;

            // Assert
            Assert.True(myInstance._isAuthenticated);
        }


        [Fact]
        public void NotLoginCodeTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();

            // Act
            var cut = ctx.RenderComponent<Home>();
            var myInstance = cut.Instance;

            // Assert
            Assert.False(myInstance._isAuthenticated);
        }
    }
}