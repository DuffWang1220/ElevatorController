using ElevatorController.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static ElevatorController.Services.Enums;

namespace ElevatorController.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ElevatorController : ControllerBase
    {
        private readonly IElevator _elevator;

        public ElevatorController(IElevator elevator)
        {
            _elevator = elevator;
        }

        /// <summary>
        /// Add a new Destination that can be from a person in the Elevator Car or out of the elevator car are in the floors
        /// </summary>
        /// <param name="floorNumber"></param>
        [HttpPost]
        public void AddNewDestination([FromBody] int floorNumber)
        {
            _elevator.AddNewDestination(floorNumber);
        }

        /// <summary>
        /// Return the current floor of Elevaror Car
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetCurrentFloor()
        {
            return _elevator.GetCurrent();
        }

        /// <summary>
        /// Return the direction of elevator 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Direction GetElevatorDirection()
        {
            return _elevator.GetDirection();
        }

        /// <summary>
        /// Return the floor number of next destination of elevaror
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetNextDestionationFloor()
        {
            return _elevator.GetNextDestionation();
        }

        /// <summary>
        /// Return the totall number of requested that send to elevator system 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetTotalRequests()
        {
            return _elevator.GetTotalRequests();
        }

        /// <summary>
        /// The Elevaror give an instruction to the system to move to next destination
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool MoveAndCheckIfServed()
        {
            return _elevator.MoveAndCheckIfServed();
        }
    }
}