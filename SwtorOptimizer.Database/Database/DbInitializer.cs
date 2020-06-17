using SwtorOptimizer.Business.Entities;
using System.Linq;

namespace SwtorOptimizer.Database.Database
{
    public static class DbInitializer
    {
        public static void Initialize(SwtorOptimizerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Enhancements.Any()) return;

            var enhancements = new Enhancement[]
            {
                new Enhancement { Name = "R1", Power = 313,  Tertiary = 431, Endurance = 285 },
                new Enhancement { Name = "R2", Power = 316,  Tertiary = 429, Endurance = 285 },
                new Enhancement { Name = "R3", Power = 318,  Tertiary = 427, Endurance = 285 },
                new Enhancement { Name = "R4", Power = 321,  Tertiary = 424, Endurance = 285 },
                new Enhancement { Name = "R5", Power = 324,  Tertiary = 422, Endurance = 285 },
                new Enhancement { Name = "R6", Power = 326,  Tertiary = 420, Endurance = 285 },
                new Enhancement { Name = "R7", Power = 329,  Tertiary = 418, Endurance = 285 },
                new Enhancement { Name = "R8", Power = 331,  Tertiary = 416, Endurance = 285 },
                new Enhancement { Name = "R9", Power = 334,  Tertiary = 414, Endurance = 285 },
                new Enhancement { Name = "R10", Power = 337, Tertiary = 412, Endurance = 285 },
                new Enhancement { Name = "R11", Power = 339, Tertiary = 409, Endurance = 285 },
                new Enhancement { Name = "R12", Power = 342, Tertiary = 407, Endurance = 285 },
                new Enhancement { Name = "R13", Power = 344, Tertiary = 405, Endurance = 285 },
                new Enhancement { Name = "R14", Power = 347, Tertiary = 403, Endurance = 285 },
                new Enhancement { Name = "R15", Power = 349, Tertiary = 401, Endurance = 285 },
                new Enhancement { Name = "R16", Power = 352, Tertiary = 398, Endurance = 285 },
                new Enhancement { Name = "R17", Power = 354, Tertiary = 396, Endurance = 285 },
                new Enhancement { Name = "R18", Power = 357, Tertiary = 394, Endurance = 285 },
                new Enhancement { Name = "R19", Power = 359, Tertiary = 392, Endurance = 285 },
                new Enhancement { Name = "R20", Power = 361, Tertiary = 389, Endurance = 285 }
            };

            context.Enhancements.AddRange(enhancements);
            context.SaveChanges();
        }
    }
}