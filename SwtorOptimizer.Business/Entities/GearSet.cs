using System.Collections.Generic;

namespace SwtorOptimizer.Business.Entities
{
    public class GearSet
    {
        public virtual CalculationTask CalculationTask { get; set; }
        public int CalculationTaskId { get; set; }
        public virtual ICollection<GearSetGearPiece> GearSetGearPieces { get; set; }
        public int Id { get; set; }
        public bool IsInvalid { get; set; }
        public string SetInternalName { get; set; }
        public string SetName { get; set; }
        public int Threshold { get; set; }
    }
}