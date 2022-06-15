#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptikerService.Controllers;
using OptikerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OptikerService.Controllers.BrillenTester
{
    [TestClass()]
    public class brillensControllerTest
    {
        private readonly brillensController _controller;
        private readonly optikerdbContext _context;

        // Weiß nicht warum, IsType nicht funktioniert, da ich bei suchen immer nur UnitTest Beispiel mit "IsType" finde.

        [TestMethod()]
        public void brillensControllerAllBrillenTester()
        {
            var _context = new optikerdbContext();
            var _controller = new brillensController(_context);
        }

        //GET

        [Fact]
        public async void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.Getbrillen();

            //Assert
            
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void Get_WhenCaleed_ReturnsAllItems()
        {
            //Act
            var okResult = _controller.Getbrillen() as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<brillen>>(okResult.Value);
            Assert.Equals(3, items.Count());
        }

        //ADD
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new brillen()
            {
                modellid = 1,
                name = "Tommy Test Fake"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Postbrillen(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            brillen testItem = new brillen()
            {
                modellid = 9,
                name = "Tommy Test",
                art = "Vollrand",
                preis = 120.00M,
                glasart = "Sonnenbrille",
                staerke = 0,
                stueck = 5
            };

            // Act
            var createdResponse = _controller.Postbrillen(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new brillen()
            {
                modellid = 10,
                name = "Tommy Test 3",
                art = "Vollrand",
                preis = 300.00M,
                glasart = "Sonnenbrille",
                staerke = 0,
                stueck = 2
            };

            // Act
            var createdResponse = _controller.Postbrillen(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as brillen;

            // Assert
            Assert.IsType<<brillen>(item);
            Assert.Equals("Tommy Test 3", item.name);
        }

    }
}