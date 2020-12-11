import { CalculationTaskStatus } from '../enums/CalculationTaskStatus';
import { ICalculationTask } from '../models/ICalculationTask';

export default class CalculationTaskHelper {
  static getTaskStatus(task: ICalculationTask): string {
    const status = task.status as CalculationTaskStatus;
    switch (status) {
      case CalculationTaskStatus.Idle:
        return 'En attente de lancement';
      case CalculationTaskStatus.Ended:
        return 'Terminée';
      case CalculationTaskStatus.Started:
        return 'Calcul en cours';
      case CalculationTaskStatus.Stopped:
        return 'Arrêtée';
      case CalculationTaskStatus.Faulted:
        return 'Erreur';
      default:
        return 'Statut inconnu';
    }
  }
}
