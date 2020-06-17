namespace SwtorOptimizer.Business.Entities
{
    public class EnhancementSetEnhancement
    {
        public Enhancement Enhancement { get; set; }
        public int EnhancementId { get; set; }
        public EnhancementSet EnhancementSet { get; set; }
        public int EnhancementSetId { get; set; }
        public int Id { get; set; }
    }
}