using AE.Application.Modules.ShipModule.Commands;
using AE.Application.Modules.ShipModule.Commands.CommandModels;
using AE.Application.Repository;
using AE.Data.Entities;
using AE.UnitTesting.Mapping;
using AutoMapper;
using Moq;
using AE.Application.Modules.ShipModule.Queries.Models;
using AE.Application.Modules.ShipModule.Queries;
using AE.Common.Exceptions;

namespace AE.UnitTesting
{
    public class ShipTest
    {
        private Mock<IRepository<Ship>> _mockShiprepository;
        private Mock<IMapper> _mockMapper;
        [SetUp]
        public void Setup()
        {
            _mockShiprepository = new();
            _mockMapper = new();
        }

        [Test]
        public async Task Ship_Create_ValidInput()
        {
            //Assert
            var createShipCommand = new CreateShipCommand
            {
                Name = "Ship 1",
                Latitude =  12.1,
                Longtitude = -92.2,
                Velocity = 21
            };
            var _mockShipCommandHander = new ShipCommandHandler(_mockShiprepository.Object, MapperConfig.InitFromBaseProject());
            //Act
            var result = await _mockShipCommandHander.Handle(createShipCommand, default);

            Assert.That(result.Message, Is.EqualTo("Success"));
        }



        [Test]
        public async Task Ship_Create_InValidInput()
        {
            //Assert
            var createShipCommand = new CreateShipCommand
            {
                Name = "Ship Invalid Input",
                Latitude =1212.1,
                Longtitude = -92.2,
                Velocity = 21
            };
            var _mockShipCommandHander = new ShipCommandHandler(_mockShiprepository.Object, MapperConfig.InitFromBaseProject());
            //Act
            Assert.ThrowsAsync<CustomValidationException>(() =>  _mockShipCommandHander.Handle(createShipCommand, default));
        }
    }
}