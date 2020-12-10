import { IGearSet } from './IGearSet';

export interface ICalculationTask {
  id: number;
  threshold: number;
  foundSets: number;
  status: number;
  startDate: Date;
  lastUpdate: Date;
  endDate: Date;
  enhancementSets: IGearSet[];
}
