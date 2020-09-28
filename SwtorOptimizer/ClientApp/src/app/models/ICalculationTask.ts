import { IEnhancementSet } from './IEnhancementSet';

export interface ICalculationTask {
  id: number;
  threshold: number;
  foundSets: number;
  status: number;
  startDate: Date;
  endDate: Date;
  enhancementSets: IEnhancementSet[];
}
