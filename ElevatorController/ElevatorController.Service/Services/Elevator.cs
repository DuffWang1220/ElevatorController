using ElevatorController.Services.Interfaces;
using static ElevatorController.Services.Enums;

namespace ElevatorController.Services.Services
{
    public class Elevator : IElevator
    {
        private readonly IElevatorRepository _evelatorRepository;
        private int _currentFloor;

        Direction _direction;

        public Elevator(IElevatorRepository evelatorRepository)
        {
            _evelatorRepository = evelatorRepository;
            _currentFloor = 0;
            _direction = Enums.Direction.None;
        }

        public void AddNewDestination(int destination)
        {
            if (destination > _currentFloor)
            {
                //_upDestinationFloors.Add(destination);
                _evelatorRepository.AddUpDestination();
                //_upDestinationFloors.Sort();
            }
            else
            {
                //_downDestinationFloors.Add(destination);
                _evelatorRepository.AddDownDestination();
                //_downDestinationFloors.Sort();
                //_downDestinationFloors.Reverse();
            }
        }
        public int GetCurrent()
        {
            return _currentFloor;
        }
        public Direction GetDirection()
        {
            return _direction;
        }
        public int GetNextDestionation()
        {
            if (_direction == Enums.Direction.Down)
            {
                return _evelatorRepository.GetDestinationDownFloor().FloorNumber;
            }
            else if (_direction == Enums.Direction.Up)
            {
                return _evelatorRepository.GetDestinationUpFloor().FloorNumber;
            }
            else
            {
                return 0;
            }
        }
        public int GetTotalRequests()
        {
            return _evelatorRepository.GetDestinationUpFloorCount() + _evelatorRepository.GetDestinationDownFloorCount();
        }
        public bool MoveAndCheckIfServed()
        {
            Direction();
            if (_direction == Enums.Direction.Up)
            {
                if (_evelatorRepository.GetDestinationUpFloor().FloorNumber == _currentFloor)
                {
                    return PopUpDestionation();
                }
                else
                {
                    _currentFloor++;
                }
            }
            else if (_direction == Enums.Direction.Down)
            {
                if (_evelatorRepository.GetDestinationDownFloor().FloorNumber == _currentFloor)
                {
                    return PopDownDestionation();
                }
                else
                {
                    _currentFloor--;
                }
            }
            else
            {
            }
            return false;
        }

        private void Direction()
        {
            if (_direction == Enums.Direction.None)
            {
                if (_evelatorRepository.GetDestinationUpFloorCount() > 0 && _evelatorRepository.GetDestinationDownFloorCount() > 0)
                {
                    if (Math.Abs(_currentFloor - _evelatorRepository.GetDestinationUpFloor().FloorNumber) < Math.Abs(_currentFloor - _evelatorRepository.GetDestinationDownFloor().FloorNumber))
                    {
                        _direction = Enums.Direction.Up;
                    }
                    else
                    {
                        _direction = Enums.Direction.Down;
                    }
                }
                else if (_evelatorRepository.GetDestinationUpFloorCount() > 0)
                {
                    _direction = Enums.Direction.Up;
                }
                else if (_evelatorRepository.GetDestinationDownFloorCount() > 0)
                {
                    _direction = Enums.Direction.Down;
                }
            }
        }
        private bool PopUpDestionation()
        {
            _evelatorRepository.RemoveUpDestinationFloor(_evelatorRepository.GetDestinationUpFloor().FloorNumber);
            if (_evelatorRepository.GetDestinationUpFloorCount() == 0)
            {
                _direction = Enums.Direction.None;
            }
            return true;
        }
        private bool PopDownDestionation()
        {
            _evelatorRepository.RemoveDownDestinationFloor(_evelatorRepository.GetDestinationDownFloor().FloorNumber);
            if (_evelatorRepository.GetDestinationDownFloorCount() == 0)
            {
                _direction = Enums.Direction.None;
            }
            return true;
        }
    }
}
