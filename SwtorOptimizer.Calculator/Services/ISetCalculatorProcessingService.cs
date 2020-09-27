using System.Collections.Generic;
using System.Threading.Tasks;
using SwtorOptimizer.Business.Entities;

namespace SwtorOptimizer.Calculator.Services
{
    internal interface ISetCalculatorProcessingService
    {
        void StartTask(FindCombinationTask task, List<Enhancement> enhancements);
    }
}