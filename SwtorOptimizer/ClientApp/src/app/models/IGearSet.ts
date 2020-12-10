import { IGearPiece } from './IGearPiece';
import { ICalculationTask } from './ICalculationTask';

export interface IGearSet {
  id: number;
  setName: string;
  threshold: number;
  power: number;
  endurance: number;
  gearPieces: IGearPiece[];
  isInvalid: boolean;
  taskid: number;
  calculationTask: ICalculationTask;
}
