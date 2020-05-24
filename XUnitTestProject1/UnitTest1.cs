using System;
using TransportCompanyApp.Models;
using TransportCompanyApp.Controllers;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        [Fact]
        public async Task GetDriversTest()
        {
           
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.Drivers.FindAsync(It.IsAny<int>()))
                .ReturnsAsync(new Driver()
                {
                    Id = 1,
                    FullName = "Вася пупкін два",
                    PassportNum = "123456789",
                    DriverLicenseNum = "ФФФ123456",
                    ADRCertificate = true,
                    DriversWagons = null
                }).Verifiable();
            var controller = new DriversController(mockRepo.Object);

            // Act
            var result = controller.GetDriver(1);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Drivers_Put_Test_Correct()
        {
            Driver driverWithChanges = new Driver()
            {
                Id = 1,
                FullName = "Вася пупкін два",
                PassportNum = "123456789",
                DriverLicenseNum = "ФФФ123456",
                ADRCertificate = true,
                DriversWagons = null
            };
            var mockRepo = new Mock<IRepository>();

            var controller = new DriversController(mockRepo.Object);
            controller.PutDriver(driverWithChanges.Id, driverWithChanges);

            //Assert
            Assert.True(controller.ModelState.IsValid);
        }
        [Fact]
        public async Task Drivers_Put_Test_InCorrect_values()
        {
            Driver driverWithChanges = new Driver()
            {
                Id = 1,
                FullName = "ВасяAAAAAAgdsgfdsfdsfsdf",
                PassportNum = "123456789aaa",
                DriverLicenseNum = "ФФФ123456aaa",
                ADRCertificate = true,
                DriversWagons = null
            };
            var mockRepo = new Mock<IRepository>();

            var controller = new DriversController(mockRepo.Object);
            controller.PutDriver(driverWithChanges.Id, driverWithChanges);

            //Assert
            Assert.Equal(controller.ModelState.ErrorCount, 3);
        }


        [Fact]
        public async Task Drivers_Post_Test_Correct()
        {
            Driver driver = new Driver()
            {
                FullName = "Вася пупкін два",
                PassportNum = "123456789",
                DriverLicenseNum = "ФФФ123456",
                ADRCertificate = true,
                DriversWagons = null
            };
            var mockRepo = new Mock<IRepository>();

            var controller = new DriversController(mockRepo.Object);
            Task<ActionResult<Driver>> result = controller.PostDriver(driver);

            //Assert
            Assert.True(controller.ModelState.IsValid);
            Assert.NotNull(result.Id);
        }
        [Fact]
        public async Task Drivers_Post_Test_InCorrect_values()
        {
            Driver driver = new Driver()
            {
                FullName = "21321312fgcvВася пупкін два",
                PassportNum = "123456789sadsadsads",
                DriverLicenseNum = "ФФФ123456fdsfdsfds",
                ADRCertificate = true,
                DriversWagons = null
            };
            var mockRepo = new Mock<IRepository>();

            var controller = new DriversController(mockRepo.Object);
            Task<ActionResult<Driver>> result = controller.PostDriver(driver);

            //Assert
            Assert.False(controller.ModelState.IsValid);
            Assert.Equal(controller.ModelState.ErrorCount, 3);
            Assert.Null(result.Id);
        }





    }

}
