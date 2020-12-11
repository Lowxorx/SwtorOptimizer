using System.Collections.Generic;

namespace SwtorOptimizer.Business.Entities
{
    public class GearPiece
    {
        public string AccuracyName { get; set; }
        public string AlacrityName { get; set; }
        public string CriticalName { get; set; }
        public int Endurance { get; set; }
        public virtual ICollection<GearPieceSetGearPiece> GearPieceSetGearPieces { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Tertiary { get; set; }
    }
}