namespace ElevatorController.Services
{
    public class Enums
    {
        public enum Direction
        {
            /// <summary>
            /// When The Elevator is Moving Up
            /// </summary>
            Up = 1,

            /// <summary>
            /// When The Elevator is Moving DOWN
            /// </summary>
            Down = 2,

            /// <summary>
            /// When The Elevator is not moving 
            /// </summary>
            None = 3
        }
    }
}
