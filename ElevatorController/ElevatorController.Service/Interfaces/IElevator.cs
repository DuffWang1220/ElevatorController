
using static ElevatorController.Services.Enums;

namespace ElevatorController.Services.Interfaces
{
    public interface IElevator
    {
        /// <summary>
        /// Get the next destination floor
        /// </summary>
        /// <returns>next destination number</returns>
        int GetNextDestionation();

        /// <summary>
        /// get the current floor of elevator
        /// </summary>
        /// <returns>current floor</returns>
        int GetCurrent();

        /// <summary>
        /// Add a new pickUpDestination to elevator
        /// </summary>
        /// <param name="destination"></param>
        void AddNewDestination(int destination);

        /// <summary>
        /// moves the elevator 1 floor at a time based on pickUp request and Elevator Service Algorithm.
        /// </summary>
        /// <returns></returns>
        bool MoveAndCheckIfServed();

        /// <summary>
        /// Get the direction of elevator's movement. Response - Elevator_Up or Elevator_Down or Elevator_None
        /// </summary>
        /// <returns>ElevatorDirection</returns>
        Direction GetDirection();

        /// <summary>
        /// Get the total number of pickUpRequests queued for this elevator
        /// </summary>
        /// <returns>Numbers of all requests</returns>
        int GetTotalRequests();
    }
}
