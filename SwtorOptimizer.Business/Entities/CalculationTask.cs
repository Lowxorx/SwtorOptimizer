using System;
using System.Collections.Generic;

namespace SwtorOptimizer.Business.Entities
{
    public class CalculationTask
    {
        public DateTime EndDate { get; set; }
        public virtual ICollection<GearPieceSet> GearPieceSets { get; set; }
        public int FoundSets { get; set; }
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime StartDate { get; set; }
        public CalculationTaskStatus Status { get; set; }
        public int Threshold { get; set; }
    }
}