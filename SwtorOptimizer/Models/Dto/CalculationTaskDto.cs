using System;
using System.Collections.Generic;

namespace SwtorOptimizer.Models.Dto
{
    public class CalculationTaskDto
    {
        public DateTime EndDate { get; set; }
        public List<GearPieceSetDto> GearPieceSets { get; set; }
        public int FoundSets { get; set; }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int Status { get; set; }
        public int Threshold { get; set; }
    }
}