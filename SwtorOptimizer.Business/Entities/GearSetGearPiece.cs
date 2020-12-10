namespace SwtorOptimizer.Business.Entities
{
    public class GearSetEnhancement
    {
        public GearPiece GearPiece { get; set; }
        public int EnhancementId { get; set; }
        public GearSet GearSet { get; set; }
        public int GearSetId { get; set; }
        public int Id { get; set; }
    }
}