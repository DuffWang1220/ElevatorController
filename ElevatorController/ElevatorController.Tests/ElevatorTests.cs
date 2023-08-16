using ElevatorController.Services.Interfaces;
using ElevatorController.Services.Repositories;
using ElevatorController.Services.Services;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using static ElevatorController.Services.Enums;

namespace ElevatorController.Tests
{
    public class ElevatorTests
    {
        private readonly IElevator _elevator;
        private readonly IElevatorRepository _elevatorRepository;

        public ElevatorTests()
        {
            _elevator = A.Fake<IElevator>();
            _elevatorRepository = A.Fake<IElevatorRepository>();
        }

        [Fact]
        public void AddNewDestinationTotalRequest()
        {
            var elevator = new Elevator(_elevatorRepository);

            elevator.AddNewDestination(1);
            var result = elevator.GetTotalRequests();

            result.Should().BeGreaterThan(0);
            result.Should().Be(1);
        }

        [Fact]
        public void GetCurrentFloorReturnInt()
        {
            var elevator = new Elevator(_elevatorRepository);
            var result = elevator.GetCurrent();
            result.Should().Be(0);
        }

        [Fact]
        public void GetDirectionReturnNone()
        {
            var elevator = new Elevator(_elevatorRepository);
            var result = elevator.GetDirection();
            result.Should().Be(Direction.None);
        }

        [Fact]
        public void GetTotalRequestsReturnInt()
        {
            var elevator = new Elevator(_elevatorRepository);
            elevator.AddNewDestination(1);
            elevator.AddNewDestination(2);
            elevator.AddNewDestination(3);
            var result = elevator.GetTotalRequests();
            result.Should().Be(3);
        }

        [Fact]
        public void MoveAndCheckIfServedReturnFloorNumber()
        {
            var elevator = new Elevator(_elevatorRepository);
            elevator.AddNewDestination(1);
            elevator.AddNewDestination(2);
            elevator.AddNewDestination(3);
            var result1 = elevator.MoveAndCheckIfServed();
            var result2 = elevator.GetCurrent();
            var result3 = elevator.GetNextDestionation();
            result1.Should().Be(false);
            result2.Should().Be(1);
            result3.Should().Be(1);
        }

    }
}
