using System.Collections.Generic;

namespace SwtorOptimizer.Business.Entities
{
    public class Enhancement
    {
        public int Endurance { get; set; }
        public int Mastery { get; set; }
        public virtual ICollection<GearSetEnhancement> GearSetEnhancements { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Tertiary { get; set; }
    }
}