
using ElevatorController.DataModel;

namespace ElevatorController.Services.Interfaces
{
    public interface IElevatorRepository
    {
        void AddUpDestination();
        void AddDownDestination();
        DestinationFloor GetDestinationUpFloor();
        DestinationFloor GetDestinationDownFloor();
        int GetDestinationDownFloorCount();
        int GetDestinationUpFloorCount();
        void RemoveUpDestinationFloor(int floorNumber);
        void RemoveDownDestinationFloor(int floorNumber);
    }
}
