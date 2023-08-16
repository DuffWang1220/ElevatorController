using ElevatorController.Api.Controllers;
using ElevatorController.Services.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using static ElevatorController.Services.Enums;

namespace ElevatorController.Tests
{
    public class ElevatorControllerTests
    {
        private readonly IElevator _elevator;
        public ElevatorControllerTests()
        {
            _elevator = A.Fake<IElevator>();
        }

        [Fact]
        public void AddDestinationReturnOne()
        {
            A.CallTo(() => _elevator.AddNewDestination(1));
            A.CallTo(() => _elevator.GetTotalRequests()).Returns(1);
            var controller = new Api.Controllers.ElevatorController(_elevator);

            controller.AddNewDestination(1);
            var result = controller.GetTotalRequests();

            result.Should().BeGreaterThan(0);
            result.Should().Be(1);
        }

        [Fact]
        public void GetCurrentFloorReturnZero()
        {
            A.CallTo(() => _elevator.GetTotalRequests()).Returns(0);
            var controller = new Api.Controllers.ElevatorController(_elevator);

            var result = controller.GetTotalRequests();

            result.Should().Be(0);
        }

        [Fact]
        public void GetElevatorDirectionReturnNone()
        {
            A.CallTo(() => _elevator.GetDirection()).Returns(Direction.None);
            var controller = new Api.Controllers.ElevatorController(_elevator);

            var result = controller.GetElevatorDirection();

            result.Should().Be(Direction.None);
        }

        [Fact]
        public void GetNextDestionationFloorReturnNone()
        {
            A.CallTo(() => _elevator.GetNextDestionation()).Returns(2);
            var controller = new Api.Controllers.ElevatorController(_elevator);

            var result = controller.GetNextDestionationFloor();

            result.Should().Be(2);
        }

        [Fact]
        public void GetTotalRequestsReturnTwo()
        {
            A.CallTo(() => _elevator.GetTotalRequests()).Returns(2);
            var controller = new Api.Controllers.ElevatorController(_elevator);

            var result = controller.GetTotalRequests();

            result.Should().Be(2);
        }

        [Fact]
        public void MoveAndCheckIfServedReturnTwo()
        {
            A.CallTo(() => _elevator.MoveAndCheckIfServed()).Returns(false);
            var controller = new Api.Controllers.ElevatorController(_elevator);

            var result = controller.MoveAndCheckIfServed();

            result.Should().Be(false);
        }
    }
}
