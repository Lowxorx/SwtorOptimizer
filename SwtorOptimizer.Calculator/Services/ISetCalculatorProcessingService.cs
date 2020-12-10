using System.Collections.Generic;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Calculator.Services
{
    internal interface ISetCalculatorProcessingService
    {
        void StartTask(CalculationTask task, List<GearPiece> gearPieces);
    }
}