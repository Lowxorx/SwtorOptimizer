import { ICalculationTask } from './ICalculationTask';

export interface ICalculationTaskFront extends ICalculationTask {
  duration: string;
  statusDisplayName: string;
}
