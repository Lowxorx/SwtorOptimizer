import { IEnhancement } from "./IEnhancement";
import { IFindCombinationTask } from "./IFindCombinationTask";

export interface IEnhancementSet {
  id: number;
  setName: string;
  threshold: number;
  power: number;
  enhancements: IEnhancement[];
  isInvalid: boolean;
  findCombinationTaskId: number;
  findCombinationTask: IFindCombinationTask;
}
