using System;

namespace SwtorOptimizer.Business.Entities
{
    public class FindCombinationTask
    {
        public DateTime EndDate { get; set; }
        public int FoundSets { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public FindCombinationTaskStatus Status { get; set; }
        public int Threshold { get; set; }
    }
}