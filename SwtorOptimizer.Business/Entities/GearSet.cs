using System.Collections.Generic;

namespace SwtorOptimizer.Business.Entities
{
    public class EnhancementSet
    {
        public virtual CalculationTask CalculationTask { get; set; }
        public int CalculationTaskId { get; set; }
        public virtual ICollection<EnhancementSetEnhancement> EnhancementSetEnhancements { get; set; }
        public int Id { get; set; }
        public bool IsInvalid { get; set; }
        public string SetInternalName { get; set; }
        public string SetName { get; set; }
        public int Threshold { get; set; }
    }
}