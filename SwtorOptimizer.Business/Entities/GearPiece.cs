using System.Collections.Generic;
using SwtorOptimizer.Business.Enums;

namespace SwtorOptimizer.Business.Entities
{
    public class GearPiece
    {
        public int Endurance { get; set; }
        public int Mastery { get; set; }
        public virtual ICollection<GearSetGearPiece> GearSetEnhancements { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Tertiary { get; set; }
        public GearPieceType GearPieceType { get; set; }
        public GearPieceStat GearPieceStat { get; set; }
    }
}