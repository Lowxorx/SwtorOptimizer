import { IFindCombinationTask } from "./IFindCombinationTask";

export interface IFindCombinationTaskFront extends IFindCombinationTask {
  duration: string;
  statusDisplayName: string;
}