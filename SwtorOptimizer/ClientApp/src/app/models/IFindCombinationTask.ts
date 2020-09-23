import { IEnhancementSet } from "./IEnhancementSet";

export interface IFindCombinationTask {
  id: number;
  threshold: number;
  foundSets: number;
  status: number;
  startDate: Date;
  endDate: Date;
  enhancementSetDtos: IEnhancementSet[];
}
