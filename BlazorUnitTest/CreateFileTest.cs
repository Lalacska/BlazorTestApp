using BlazorTestApp.Components.Pages;
using Bunit;
using Bunit.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUnitTest
{
    public class CreateFileTest
    {
        [Fact]
        public void CreateTest()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("");

            // Act
            var cut = ctx.RenderComponent<Home>();

            var task = cut.Instance.CreateFile(); 
            var created = task.Result;

            // Assert
            // Check if the method for creating the file is called
            Assert.True(created);

        }
    }
}
