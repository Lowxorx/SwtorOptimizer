namespace SwtorOptimizer.Business.Entities
{
    public class GearPieceSetGearPiece
    {
        public GearPiece GearPiece { get; set; }
        public int GearPieceId { get; set; }
        public GearPieceSet GearPieceSet { get; set; }
        public int GearPieceSetId { get; set; }
        public int Id { get; set; }
    }
}