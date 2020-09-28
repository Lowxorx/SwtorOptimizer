import { IEnhancement } from './IEnhancement';
import { ICalculationTask } from './ICalculationTask';

export interface IEnhancementSet {
  id: number;
  setName: string;
  threshold: number;
  power: number;
  endurance: number;
  enhancements: IEnhancement[];
  isInvalid: boolean;
  taskid: number;
  calculationTask: ICalculationTask;
}
