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

            var typeOneEnhancements = new[]
            {
                new Enhancement { Name = "R1", Power = 313,  Tertiary = 431, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R2", Power = 316,  Tertiary = 429, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R3", Power = 318,  Tertiary = 427, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R4", Power = 321,  Tertiary = 424, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R5", Power = 324,  Tertiary = 422, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R6", Power = 326,  Tertiary = 420, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R7", Power = 329,  Tertiary = 418, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R8", Power = 331,  Tertiary = 416, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R9", Power = 334,  Tertiary = 414, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R10", Power = 337, Tertiary = 412, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R11", Power = 339, Tertiary = 409, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R12", Power = 342, Tertiary = 407, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R13", Power = 344, Tertiary = 405, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R14", Power = 347, Tertiary = 403, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R15", Power = 349, Tertiary = 401, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R16", Power = 352, Tertiary = 398, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R17", Power = 354, Tertiary = 396, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R18", Power = 357, Tertiary = 394, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R19", Power = 359, Tertiary = 392, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" },
                new Enhancement { Name = "R20", Power = 361, Tertiary = 389, Endurance = 285, AccuracyName  =  "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte" }
            };

            var typeTwoEnhancements = new[]
            {
                new Enhancement { Name = "R0", Power = 140,  Tertiary = 409, Endurance = 431, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R1", Power = 347,  Tertiary = 347, Endurance = 349, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R2", Power = 344,  Tertiary = 347, Endurance = 352, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R3", Power = 344,  Tertiary = 344, Endurance = 354, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R4", Power = 342,  Tertiary = 344, Endurance = 357, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R5", Power = 342,  Tertiary = 342, Endurance = 359, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R6", Power = 339,  Tertiary = 342, Endurance = 361, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R7", Power = 339,  Tertiary = 339, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R8", Power = 337,  Tertiary = 342, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R9", Power = 334,  Tertiary = 344, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R10", Power = 331, Tertiary = 347, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R11", Power = 329, Tertiary = 349, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R12", Power = 326, Tertiary = 352, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R13", Power = 324, Tertiary = 354, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R14", Power = 321, Tertiary = 357, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R15", Power = 318, Tertiary = 359, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R16", Power = 316, Tertiary = 361, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R17", Power = 313, Tertiary = 364, Endurance = 364, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R18", Power = 310, Tertiary = 364, Endurance = 366, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R19", Power = 307, Tertiary = 364, Endurance = 369, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" },
                new Enhancement { Name = "R20", Power = 305, Tertiary = 364, Endurance = 371, AccuracyName  =  "Étude", AlacrityName = "Barrage", CriticalName = "Discipline" }
            };

            var typeThreeEnhancements = new[]
            {
                new Enhancement { Name = "R0", Power = 221,  Tertiary = 431, Endurance = 364, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R1", Power = 255,  Tertiary = 451, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R2", Power = 258,  Tertiary = 449, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R3", Power = 261,  Tertiary = 447, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R4", Power = 264,  Tertiary = 445, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R5", Power = 267,  Tertiary = 443, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R6", Power = 270,  Tertiary = 441, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R7", Power = 273,  Tertiary = 439, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R8", Power = 276,  Tertiary = 437, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R9", Power = 279,  Tertiary = 435, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R10", Power = 282, Tertiary = 433, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R11", Power = 285, Tertiary = 431, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R12", Power = 288, Tertiary = 429, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R13", Power = 291, Tertiary = 427, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R14", Power = 294, Tertiary = 424, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R15", Power = 296, Tertiary = 422, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R16", Power = 299, Tertiary = 420, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R17", Power = 302, Tertiary = 418, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R18", Power = 305, Tertiary = 416, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R19", Power = 307, Tertiary = 414, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" },
                new Enhancement { Name = "R20", Power = 310, Tertiary = 412, Endurance = 313, AccuracyName  =  "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité" }
            };

            context.Enhancements.AddRange(typeOneEnhancements);
            context.Enhancements.AddRange(typeTwoEnhancements);
            context.Enhancements.AddRange(typeThreeEnhancements);
            context.SaveChanges();
        }
    }
}