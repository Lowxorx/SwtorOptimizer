using System;

namespace SwtorOptimizer.Business.Entities
{
    public class FindCombinationTask
    {
        public DateTime EndDate { get; set; }
        public int FoundSets { get; set; }
        public int Id { get; set; }
        public bool IsEnded { get; set; }
        public bool IsFaulted { get; set; }
        public bool IsRunning { get; set; }
        public bool IsStarted { get; set; }
        public DateTime StartDate { get; set; }
        public int Threshold { get; set; }
    }
}