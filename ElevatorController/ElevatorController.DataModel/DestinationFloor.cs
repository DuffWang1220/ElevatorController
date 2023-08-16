using System.ComponentModel.DataAnnotations.Schema;

namespace ElevatorController.DataModel
{
    public class DestinationFloor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public bool IsUp { get; set; }
    }
}
