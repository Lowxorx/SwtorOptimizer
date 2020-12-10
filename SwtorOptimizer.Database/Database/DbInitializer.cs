using SwtorOptimizer.Business.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SwtorOptimizer.Business.Enums;

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
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R1 Initiative", Power = 313,  Tertiary = 431, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R2 Initiative", Power = 316,  Tertiary = 429, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R3 Initiative", Power = 318,  Tertiary = 427, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R4 Initiative", Power = 321,  Tertiary = 424, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R5 Initiative", Power = 324,  Tertiary = 422, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R6 Initiative", Power = 326,  Tertiary = 420, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R7 Initiative", Power = 329,  Tertiary = 418, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R8 Initiative", Power = 331,  Tertiary = 416, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R9 Initiative", Power = 334,  Tertiary = 414, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R10 Initiative", Power = 337, Tertiary = 412, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R11 Initiative", Power = 339, Tertiary = 409, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R12 Initiative", Power = 342, Tertiary = 407, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R13 Initiative", Power = 344, Tertiary = 405, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R14 Initiative", Power = 347, Tertiary = 403, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R15 Initiative", Power = 349, Tertiary = 401, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R16 Initiative", Power = 352, Tertiary = 398, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R17 Initiative", Power = 354, Tertiary = 396, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R18 Initiative", Power = 357, Tertiary = 394, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R19 Initiative", Power = 359, Tertiary = 392, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Accuracy, Name = "R20 Initiative", Power = 361, Tertiary = 389, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R1 Aisance", Power = 313,  Tertiary = 431, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R2 Aisance", Power = 316,  Tertiary = 429, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R3 Aisance", Power = 318,  Tertiary = 427, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R4 Aisance", Power = 321,  Tertiary = 424, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R5 Aisance", Power = 324,  Tertiary = 422, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R6 Aisance", Power = 326,  Tertiary = 420, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R7 Aisance", Power = 329,  Tertiary = 418, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R8 Aisance", Power = 331,  Tertiary = 416, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R9 Aisance", Power = 334,  Tertiary = 414, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R10 Aisance", Power = 337, Tertiary = 412, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R11 Aisance", Power = 339, Tertiary = 409, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R12 Aisance", Power = 342, Tertiary = 407, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R13 Aisance", Power = 344, Tertiary = 405, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R14 Aisance", Power = 347, Tertiary = 403, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R15 Aisance", Power = 349, Tertiary = 401, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R16 Aisance", Power = 352, Tertiary = 398, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R17 Aisance", Power = 354, Tertiary = 396, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R18 Aisance", Power = 357, Tertiary = 394, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R19 Aisance", Power = 359, Tertiary = 392, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Alacrity, Name = "R20 Aisance", Power = 361, Tertiary = 389, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R1 Adepte", Power = 313,  Tertiary = 431, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R2 Adepte", Power = 316,  Tertiary = 429, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R3 Adepte", Power = 318,  Tertiary = 427, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R4 Adepte", Power = 321,  Tertiary = 424, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R5 Adepte", Power = 324,  Tertiary = 422, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R6 Adepte", Power = 326,  Tertiary = 420, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R7 Adepte", Power = 329,  Tertiary = 418, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R8 Adepte", Power = 331,  Tertiary = 416, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R9 Adepte", Power = 334,  Tertiary = 414, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R10 Adepte", Power = 337, Tertiary = 412, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R11 Adepte", Power = 339, Tertiary = 409, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R12 Adepte", Power = 342, Tertiary = 407, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R13 Adepte", Power = 344, Tertiary = 405, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R14 Adepte", Power = 347, Tertiary = 403, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R15 Adepte", Power = 349, Tertiary = 401, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R16 Adepte", Power = 352, Tertiary = 398, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R17 Adepte", Power = 354, Tertiary = 396, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R18 Adepte", Power = 357, Tertiary = 394, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R19 Adepte", Power = 359, Tertiary = 392, Endurance = 285, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement, GearPieceStat = GearPieceStat.Critical, Name = "R20 Adepte", Power = 361, Tertiary = 389, Endurance = 285, Mastery = 0 }
            };

            var typeTwoEnhancements = new[]
            {
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R0 Étude", Power = 140,  Tertiary = 409, Endurance = 431, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R1 Étude", Power = 347,  Tertiary = 347, Endurance = 349, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R2 Étude", Power = 344,  Tertiary = 347, Endurance = 352, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R3 Étude", Power = 344,  Tertiary = 344, Endurance = 354, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R4 Étude", Power = 342,  Tertiary = 344, Endurance = 357, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R5 Étude", Power = 342,  Tertiary = 342, Endurance = 359, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R6 Étude", Power = 339,  Tertiary = 342, Endurance = 361, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R7 Étude", Power = 339,  Tertiary = 339, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R8 Étude", Power = 337,  Tertiary = 342, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R9 Étude", Power = 334,  Tertiary = 344, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R10 Étude", Power = 331, Tertiary = 347, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R11 Étude", Power = 329, Tertiary = 349, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R12 Étude", Power = 326, Tertiary = 352, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R13 Étude", Power = 324, Tertiary = 354, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R14 Étude", Power = 321, Tertiary = 357, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R15 Étude", Power = 318, Tertiary = 359, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R16 Étude", Power = 316, Tertiary = 361, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R17 Étude", Power = 313, Tertiary = 364, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R18 Étude", Power = 310, Tertiary = 364, Endurance = 366, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R19 Étude", Power = 307, Tertiary = 364, Endurance = 369, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R20 Étude", Power = 305, Tertiary = 364, Endurance = 371 , Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R0 Barrage", Power = 140,  Tertiary = 409, Endurance = 431, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R1 Barrage", Power = 347,  Tertiary = 347, Endurance = 349, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R2 Barrage", Power = 344,  Tertiary = 347, Endurance = 352, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R3 Barrage", Power = 344,  Tertiary = 344, Endurance = 354, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R4 Barrage", Power = 342,  Tertiary = 344, Endurance = 357, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R5 Barrage", Power = 342,  Tertiary = 342, Endurance = 359, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R6 Barrage", Power = 339,  Tertiary = 342, Endurance = 361, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R7 Barrage", Power = 339,  Tertiary = 339, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R8 Barrage", Power = 337,  Tertiary = 342, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R9 Barrage", Power = 334,  Tertiary = 344, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R10 Barrage", Power = 331, Tertiary = 347, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R11 Barrage", Power = 329, Tertiary = 349, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R12 Barrage", Power = 326, Tertiary = 352, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R13 Barrage", Power = 324, Tertiary = 354, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R14 Barrage", Power = 321, Tertiary = 357, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R15 Barrage", Power = 318, Tertiary = 359, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R16 Barrage", Power = 316, Tertiary = 361, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R17 Barrage", Power = 313, Tertiary = 364, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R18 Barrage", Power = 310, Tertiary = 364, Endurance = 366, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R19 Barrage", Power = 307, Tertiary = 364, Endurance = 369, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R20 Barrage", Power = 305, Tertiary = 364, Endurance = 371, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R0 Discipline", Power = 140,  Tertiary = 409, Endurance = 431, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R1 Discipline", Power = 347,  Tertiary = 347, Endurance = 349, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R2 Discipline", Power = 344,  Tertiary = 347, Endurance = 352, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R3 Discipline", Power = 344,  Tertiary = 344, Endurance = 354, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R4 Discipline", Power = 342,  Tertiary = 344, Endurance = 357, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R5 Discipline", Power = 342,  Tertiary = 342, Endurance = 359, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R6 Discipline", Power = 339,  Tertiary = 342, Endurance = 361, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R7 Discipline", Power = 339,  Tertiary = 339, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R8 Discipline", Power = 337,  Tertiary = 342, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R9 Discipline", Power = 334,  Tertiary = 344, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R10 Discipline", Power = 331, Tertiary = 347, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R11 Discipline", Power = 329, Tertiary = 349, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R12 Discipline", Power = 326, Tertiary = 352, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R13 Discipline", Power = 324, Tertiary = 354, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R14 Discipline", Power = 321, Tertiary = 357, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R15 Discipline", Power = 318, Tertiary = 359, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R16 Discipline", Power = 316, Tertiary = 361, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R17 Discipline", Power = 313, Tertiary = 364, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R18 Discipline", Power = 310, Tertiary = 364, Endurance = 366, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R19 Discipline", Power = 307, Tertiary = 364, Endurance = 369, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R20 Discipline", Power = 305, Tertiary = 364, Endurance = 371, Mastery = 0 }
            };

            var typeThreeEnhancements = new[]
            {
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R0 Qualification", Power = 221,  Tertiary = 431, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R1 Qualification", Power = 255,  Tertiary = 451, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R2 Qualification", Power = 258,  Tertiary = 449, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R3 Qualification", Power = 261,  Tertiary = 447, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R4 Qualification", Power = 264,  Tertiary = 445, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R5 Qualification", Power = 267,  Tertiary = 443, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R6 Qualification", Power = 270,  Tertiary = 441, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R7 Qualification", Power = 273,  Tertiary = 439, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R8 Qualification", Power = 276,  Tertiary = 437, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R9 Qualification", Power = 279,  Tertiary = 435, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R10 Qualification", Power = 282, Tertiary = 433, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R11 Qualification", Power = 285, Tertiary = 431, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R12 Qualification", Power = 288, Tertiary = 429, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R13 Qualification", Power = 291, Tertiary = 427, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R14 Qualification", Power = 294, Tertiary = 424, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R15 Qualification", Power = 296, Tertiary = 422, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R16 Qualification", Power = 299, Tertiary = 420, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R17 Qualification", Power = 302, Tertiary = 418, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R18 Qualification", Power = 305, Tertiary = 416, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R19 Qualification", Power = 307, Tertiary = 414, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Accuracy, Name = "R20 Qualification", Power = 310, Tertiary = 412, Endurance = 313, Mastery = 0 }, 
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R0 Savant", Power = 221,  Tertiary = 431, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R1 Savant", Power = 255,  Tertiary = 451, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R2 Savant", Power = 258,  Tertiary = 449, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R3 Savant", Power = 261,  Tertiary = 447, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R4 Savant", Power = 264,  Tertiary = 445, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R5 Savant", Power = 267,  Tertiary = 443, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R6 Savant", Power = 270,  Tertiary = 441, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R7 Savant", Power = 273,  Tertiary = 439, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R8 Savant", Power = 276,  Tertiary = 437, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R9 Savant", Power = 279,  Tertiary = 435, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R10 Savant", Power = 282, Tertiary = 433, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R11 Savant", Power = 285, Tertiary = 431, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R12 Savant", Power = 288, Tertiary = 429, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R13 Savant", Power = 291, Tertiary = 427, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R14 Savant", Power = 294, Tertiary = 424, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R15 Savant", Power = 296, Tertiary = 422, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R16 Savant", Power = 299, Tertiary = 420, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R17 Savant", Power = 302, Tertiary = 418, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R18 Savant", Power = 305, Tertiary = 416, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R19 Savant", Power = 307, Tertiary = 414, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Alacrity, Name = "R20 Savant", Power = 310, Tertiary = 412, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R0 Efficacité", Power = 221,  Tertiary = 431, Endurance = 364, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R1 Efficacité", Power = 255,  Tertiary = 451, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R2 Efficacité", Power = 258,  Tertiary = 449, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R3 Efficacité", Power = 261,  Tertiary = 447, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R4 Efficacité", Power = 264,  Tertiary = 445, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R5 Efficacité", Power = 267,  Tertiary = 443, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R6 Efficacité", Power = 270,  Tertiary = 441, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R7 Efficacité", Power = 273,  Tertiary = 439, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R8 Efficacité", Power = 276,  Tertiary = 437, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R9 Efficacité", Power = 279,  Tertiary = 435, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R10 Efficacité", Power = 282, Tertiary = 433, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R11 Efficacité", Power = 285, Tertiary = 431, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R12 Efficacité", Power = 288, Tertiary = 429, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R13 Efficacité", Power = 291, Tertiary = 427, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R14 Efficacité", Power = 294, Tertiary = 424, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R15 Efficacité", Power = 296, Tertiary = 422, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R16 Efficacité", Power = 299, Tertiary = 420, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R17 Efficacité", Power = 302, Tertiary = 418, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R18 Efficacité", Power = 305, Tertiary = 416, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R19 Efficacité", Power = 307, Tertiary = 414, Endurance = 313, Mastery = 0 },
                new GearPiece { GearPieceType  = GearPieceType.Enhancement,GearPieceStat = GearPieceStat.Critical, Name = "R20 Efficacité", Power = 310, Tertiary = 412, Endurance = 313, Mastery = 0 }
            };
            
            context.GearPieces.AddRange(typeOneEnhancements);
            context.GearPieces.AddRange(typeTwoEnhancements);
            context.GearPieces.AddRange(typeThreeEnhancements);

            var packages = new[]
            {
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Initiative Sha'tek MK19", Power = 652, Tertiary = 431, Endurance = 1007, Mastery = 858 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Savant vif Sha'tek MK19", Power = 652, Tertiary = 431, Endurance = 1007, Mastery = 858 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Adepte Sha'tek MK19", Power = 652, Tertiary = 431, Endurance = 1007, Mastery = 858 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "InterroTek Savant MK19", Power = 538, Tertiary = 420, Endurance = 1115, Mastery = 850},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "InterroTek Qualification MK19", Power = 589, Tertiary = 387, Endurance = 1084, Mastery = 883},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "InterroTek Efficacité MK19", Power = 568, Tertiary = 431, Endurance = 1097, Mastery = 836 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Sorosuub Qualification MK19", Power = 592, Tertiary = 431, Endurance = 1114, Mastery = 809 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Sorosuub Savant MK19", Power = 592, Tertiary = 431, Endurance = 1114, Mastery = 809 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Sorosuub Efficacité MK19", Power = 589, Tertiary = 431, Endurance = 1112, Mastery = 813 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Mier-Lang Qualification MK19", Power = 575, Tertiary = 431, Endurance = 1101, Mastery = 831 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Mier-Lang Savant MK19", Power = 575, Tertiary = 431, Endurance = 1101, Mastery = 831 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Mier-Lang Efficacité MK19", Power = 562, Tertiary = 431, Endurance = 1109, Mastery = 835 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "BlasTech Qualification MK19", Power = 548, Tertiary = 431, Endurance = 1117, Mastery = 837 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "BlasTech Savant MK19", Power = 548, Tertiary = 431, Endurance = 1117, Mastery = 837 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "BlasTech Efficacité MK19", Power = 558, Tertiary = 431, Endurance = 1115, Mastery = 830},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Ord Mantell Savant (441) MK19", Power = 529, Tertiary = 441, Endurance = 1140, Mastery = 819 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Ord Mantell Savant MK19", Power = 529, Tertiary = 433, Endurance = 1140, Mastery = 819 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Ord Mantell Qualification (441) MK19", Power = 563, Tertiary = 441, Endurance = 1134, Mastery = 808},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Ord Mantell Qualification MK19", Power = 563, Tertiary = 433, Endurance = 1134, Mastery = 808 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Ord Mantell Efficacité (441) MK19", Power = 547, Tertiary = 441, Endurance = 1129, Mastery = 827 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Ord Mantell Efficacité MK19", Power = 547, Tertiary = 433, Endurance = 1129, Mastery = 827 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Sund Tech Savant MK19", Power = 585, Tertiary = 431, Endurance = 1087, Mastery = 840 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Sund Tech Qualification MK19", Power = 589, Tertiary = 429, Endurance = 1095, Mastery = 835 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Baktoid Qualification MK19", Power = 565, Tertiary = 422, Endurance = 1127, Mastery = 822},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Baktoid Savant MK19", Power = 565, Tertiary = 422, Endurance = 1127, Mastery = 822},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Baktoid Efficacité MK19", Power = 563, Tertiary = 422, Endurance = 1148, Mastery = 806, },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Systech Qualification MK19", Power = 564, Tertiary = 409, Endurance = 1128, Mastery = 843 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Systech Savant MK19", Power = 564, Tertiary = 409, Endurance = 1128, Mastery = 843 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Systech Efficacité MK19", Power = 599, Tertiary = 424, Endurance = 1105, Mastery = 820 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Critical, Name = "Arakyd Industries Qualification MK19", Power = 572, Tertiary = 431, Endurance = 1129, Mastery = 809},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Arakyd Industries Savant MK19", Power = 572, Tertiary = 431, Endurance = 1129, Mastery = 809},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Alacrity, Name = "Arakyd Industries Efficacité MK19", Power = 585, Tertiary = 431, Endurance = 1112, Mastery = 812},
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Blastech Métamorphique MK19", Power = 837, Tertiary = 431, Endurance = 1117, Mastery = 548 },
                new GearPiece { GearPieceType =  GearPieceType.Package, GearPieceStat = GearPieceStat.Accuracy, Name = "Ord Mantell Métamorphique MK19", Power = 819, Tertiary = 441, Endurance = 1140, Mastery = 529 },
            };

            context.GearPieces.AddRange(packages);
            
            var augments = new[]
            {
                new GearPiece { GearPieceType =  GearPieceType.Augment,GearPieceStat = GearPieceStat.Alacrity, Name = "Amélioration Alacrité avancée 74", Power = 144, Tertiary = 108, Endurance = 144, Mastery = 0 },
                new GearPiece { GearPieceType =  GearPieceType.Augment,GearPieceStat = GearPieceStat.Critical, Name = "Amélioration Critique avancée 74", Power = 144, Tertiary = 108, Endurance = 144, Mastery = 0 },
                new GearPiece { GearPieceType =  GearPieceType.Augment,GearPieceStat = GearPieceStat.Accuracy, Name = "Amélioration Précision avancée 74", Power = 144, Tertiary = 108, Endurance = 144, Mastery = 0 }
            };

            context.GearPieces.AddRange(augments);

            context.Users.Add(new User
            {
                Username = "admin",
                Password = "admin"
            });

            context.SaveChanges();
        }
    }
}