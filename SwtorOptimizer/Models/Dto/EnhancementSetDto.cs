using System.Collections.Generic;

namespace SwtorOptimizer.Models.Dto
{
    public class EnhancementSetDto
    {
        public List<EnhancementDto> Enhancements { get; set; }
        public int Id { get; set; }
        public bool IsInvalid { get; set; }
        public int Power { get; set; }
        public string SetName { get; set; }
        public int Threshold { get; set; }
    }
}