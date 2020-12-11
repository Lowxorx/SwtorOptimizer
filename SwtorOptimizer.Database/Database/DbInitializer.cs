using System.Linq;
using Microsoft.EntityFrameworkCore;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Database.Database
{
    public static class DbInitializer
    {
        public static void Initialize(SwtorOptimizerContext context)
        {
            context.Database.Migrate();

            if (context.GearPieces.Any())
            {
                return;
            }

            var typeOneEnhancements = new[]
            {
                new GearPiece {Name = "R1", Power = 313, Tertiary = 431, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R2", Power = 316, Tertiary = 429, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R3", Power = 318, Tertiary = 427, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R4", Power = 321, Tertiary = 424, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R5", Power = 324, Tertiary = 422, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R6", Power = 326, Tertiary = 420, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R7", Power = 329, Tertiary = 418, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R8", Power = 331, Tertiary = 416, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R9", Power = 334, Tertiary = 414, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R10", Power = 337, Tertiary = 412, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R11", Power = 339, Tertiary = 409, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R12", Power = 342, Tertiary = 407, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R13", Power = 344, Tertiary = 405, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R14", Power = 347, Tertiary = 403, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R15", Power = 349, Tertiary = 401, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R16", Power = 352, Tertiary = 398, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R17", Power = 354, Tertiary = 396, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R18", Power = 357, Tertiary = 394, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R19", Power = 359, Tertiary = 392, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"},
                new GearPiece {Name = "R20", Power = 361, Tertiary = 389, Endurance = 285, AccuracyName = "Initiative", AlacrityName = "Aisance", CriticalName = "Adepte"}
            };
            
            var typeTwoEnhancements = new[]
            {
                new GearPiece {Name = "R0", Power = 140, Tertiary = 409, Endurance = 431, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R1", Power = 347, Tertiary = 347, Endurance = 349, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R2", Power = 344, Tertiary = 347, Endurance = 352, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R3", Power = 344, Tertiary = 344, Endurance = 354, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R4", Power = 342, Tertiary = 344, Endurance = 357, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R5", Power = 342, Tertiary = 342, Endurance = 359, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R6", Power = 339, Tertiary = 342, Endurance = 361, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R7", Power = 339, Tertiary = 339, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R8", Power = 337, Tertiary = 342, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R9", Power = 334, Tertiary = 344, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R10", Power = 331, Tertiary = 347, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R11", Power = 329, Tertiary = 349, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R12", Power = 326, Tertiary = 352, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R13", Power = 324, Tertiary = 354, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R14", Power = 321, Tertiary = 357, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R15", Power = 318, Tertiary = 359, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R16", Power = 316, Tertiary = 361, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R17", Power = 313, Tertiary = 364, Endurance = 364, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R18", Power = 310, Tertiary = 364, Endurance = 366, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R19", Power = 307, Tertiary = 364, Endurance = 369, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"},
                new GearPiece {Name = "R20", Power = 305, Tertiary = 364, Endurance = 371, AccuracyName = "Étude", AlacrityName = "Barrage", CriticalName = "Discipline"}
            };

            var typeThreeEnhancements = new[]
            {
                new GearPiece {Name = "R0", Power = 221, Tertiary = 431, Endurance = 364, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R1", Power = 255, Tertiary = 451, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R2", Power = 258, Tertiary = 449, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R3", Power = 261, Tertiary = 447, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R4", Power = 264, Tertiary = 445, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R5", Power = 267, Tertiary = 443, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R6", Power = 270, Tertiary = 441, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R7", Power = 273, Tertiary = 439, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R8", Power = 276, Tertiary = 437, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R9", Power = 279, Tertiary = 435, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R10", Power = 282, Tertiary = 433, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R11", Power = 285, Tertiary = 431, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R12", Power = 288, Tertiary = 429, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R13", Power = 291, Tertiary = 427, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R14", Power = 294, Tertiary = 424, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R15", Power = 296, Tertiary = 422, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R16", Power = 299, Tertiary = 420, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R17", Power = 302, Tertiary = 418, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R18", Power = 305, Tertiary = 416, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R19", Power = 307, Tertiary = 414, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"},
                new GearPiece {Name = "R20", Power = 310, Tertiary = 412, Endurance = 313, AccuracyName = "Qualification", AlacrityName = "Savant", CriticalName = "Efficacité"}
            };

            var augments = new[]
            {
                new GearPiece {Name = "Amélioration avancée 74", Power = 144, Tertiary = 108, Endurance = 144, AccuracyName = "Précision", AlacrityName = "Alacrité", CriticalName = "Critique"}
            };

            context.GearPieces.AddRange(typeOneEnhancements);
            context.GearPieces.AddRange(typeTwoEnhancements);
            context.GearPieces.AddRange(typeThreeEnhancements);

            var packages = new[]
            {
                new Package {Name = "Sha'tek (tous) Type 19", Power = 652, Tertiary = 431, Endurance = 1007, Mastery = 858},
                new Package {Name = "InterroTek Savant Type 19", Power = 538, Tertiary = 420, Endurance = 1115, Mastery = 850},
                new Package {Name = "InterroTek Qualification Type 19", Power = 589, Tertiary = 387, Endurance = 1084, Mastery = 883},
                new Package {Name = "InterroTek Efficacité Type 19", Power = 568, Tertiary = 431, Endurance = 1097, Mastery = 836},
                new Package {Name = "Sorosuub Savant/Qualification Type 19", Power = 592, Tertiary = 431, Endurance = 1114, Mastery = 809},
                new Package {Name = "Sorosuub Efficacité Type 19", Power = 589, Tertiary = 431, Endurance = 1112, Mastery = 813},
                new Package {Name = "Mier-Lang Savant/Qualification Type 19", Power = 575, Tertiary = 431, Endurance = 1101, Mastery = 831},
                new Package {Name = "Mier-Lang Efficacité Type 19", Power = 562, Tertiary = 431, Endurance = 1109, Mastery = 835},
                new Package {Name = "BlasTech Savant/Qualification Type 19", Power = 548, Tertiary = 431, Endurance = 1117, Mastery = 837},
                new Package {Name = "BlasTech Efficacité Type 19", Power = 558, Tertiary = 431, Endurance = 1115, Mastery = 830},
                new Package {Name = "Ord Mantell Savant Type 19", Power = 529, Tertiary = 441, Endurance = 1140, Mastery = 819},
                new Package {Name = "Ord Mantell Savant Type 19", Power = 529, Tertiary = 433, Endurance = 1140, Mastery = 819},
                new Package {Name = "Ord Mantell Qualification Type 19", Power = 563, Tertiary = 441, Endurance = 1134, Mastery = 808},
                new Package {Name = "Ord Mantell Qualification Type 19", Power = 563, Tertiary = 433, Endurance = 1134, Mastery = 808},
                new Package {Name = "Ord Mantell Efficacité Type 19", Power = 547, Tertiary = 441, Endurance = 1129, Mastery = 827},
                new Package {Name = "Ord Mantell Efficacité Type 19", Power = 547, Tertiary = 433, Endurance = 1129, Mastery = 827},
                new Package {Name = "Sund Tech Savant Type 19", Power = 585, Tertiary = 431, Endurance = 1087, Mastery = 840},
                new Package {Name = "Sund Tech Qualification Type 19", Power = 589, Tertiary = 429, Endurance = 1095, Mastery = 835},
                new Package {Name = "Baktoid Savant/Qualification Type 19", Power = 565, Tertiary = 422, Endurance = 1127, Mastery = 822},
                new Package {Name = "Baktoid Efficacité Type 19", Power = 563, Tertiary = 422, Endurance = 1148, Mastery = 806},
                new Package {Name = "Systech Savant/Qualification Type 19", Power = 564, Tertiary = 409, Endurance = 1128, Mastery = 843},
                new Package {Name = "Systech Efficacité Type 19", Power = 599, Tertiary = 424, Endurance = 1105, Mastery = 820},
                new Package {Name = "Arakyd Industries Savant/Qualification Type 19", Power = 572, Tertiary = 431, Endurance = 1129, Mastery = 809},
                new Package {Name = "Arakyd Industries Efficacité Type 19", Power = 585, Tertiary = 431, Endurance = 1112, Mastery = 812},
                new Package {Name = "Blastech Métamorphique Type 19", Power = 837, Tertiary = 431, Endurance = 1117, Mastery = 548},
                new Package {Name = "Ord Mantell Métamorphique Type 19", Power = 819, Tertiary = 441, Endurance = 1140, Mastery = 529}
            };

            context.Packages.AddRange(packages);

            context.Users.Add(new User
            {
                Username = "admin",
                Password = "admin"
            });

            context.SaveChanges();
        }
    }
}