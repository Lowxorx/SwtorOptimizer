import { IGearPiece } from './IGearPiece';
import { ICalculationTask } from './ICalculationTask';

export interface IGearPieceSet {
  id: number;
  setName: string;
  threshold: number;
  power: number;
  endurance: number;
  gearPieces: IGearPiece[];
  isInvalid: boolean;
  taskid: number;
  gearPieceCount: number;
  calculationTask: ICalculationTask;
}
