using System.Collections.Generic;

namespace SwtorOptimizer.Models.Dto
{
    public class GearSetDto
    {
        public CalculationTaskDto CalculationTask { get; set; }
        public int CalculationTaskId { get; set; }
        public int Endurance { get; set; }
        public List<GearPieceDto> Enhancements { get; set; }
        public int Id { get; set; }
        public bool IsInvalid { get; set; }
        public int Power { get; set; }
        public string SetName { get; set; }
        public int Threshold { get; set; }
    }
}