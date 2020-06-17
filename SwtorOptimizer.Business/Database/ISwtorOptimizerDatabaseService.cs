using SwtorOptimizer.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwtorOptimizer.Business.Database
{
    public interface ISwtorOptimizerDatabaseService
    {
        IEnhancementRepository EnhancementRepository { get; }
        IRepository<EnhancementSetEnhancement> EnhancementSetEnhancementRepository { get; }
        IRepository<EnhancementSet> EnhancementSetRepository { get; }
        IRepository<FindCombinationTask> FindCombinationTaskRepository { get; }
    }
}