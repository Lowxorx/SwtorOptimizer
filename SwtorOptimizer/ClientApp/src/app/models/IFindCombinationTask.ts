import { IEnhancementSet } from "./IEnhancementSet";

export interface IFindCombinationTask {
  id: number;
  threshold: number;
  foundSets: number;
  isFaulted: boolean;
  isRunning: boolean;
  isStarted: boolean;
  isEnded: boolean;
  startDate: Date;
  endDate: Date;
  enhancementSetDtos: IEnhancementSet[];
}
