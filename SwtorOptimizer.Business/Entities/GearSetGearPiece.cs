namespace SwtorOptimizer.Business.Entities
{
    public class GearSetGearPiece
    {
        public GearPiece GearPiece { get; set; }
        public int GearPieceId { get; set; }
        public GearSet GearSet { get; set; }
        public int GearSetId { get; set; }
        public int Id { get; set; }
    }
}