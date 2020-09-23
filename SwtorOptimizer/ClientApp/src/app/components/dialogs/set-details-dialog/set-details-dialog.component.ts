import { Component, Inject, OnInit } from '@angular/core';
import { MatButtonToggleChange, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { IEnhancement } from 'src/app/models/IEnhancement';
import { IEnhancementSet } from 'src/app/models/IEnhancementSet';
import { IStat } from 'src/app/models/IStat';

@Component({
  selector: 'app-set-details-dialog',
  templateUrl: './set-details-dialog.component.html',
  styleUrls: ['./set-details-dialog.component.scss'],
})
export class SetDetailsDialogComponent implements OnInit {
  public enhancementSet: IEnhancementSet;
  public currentStat: IStat;
  public stats: IStat[];

  constructor(private dialogReference: MatDialogRef<SetDetailsDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: IEnhancementSet) {}

  public ngOnInit(): void {
    this.enhancementSet = this.data;
    this.stats = [
      { displayName: 'Précision', name: 'accuracy' },
      { displayName: 'Alacrité', name: 'alacrity' },
      { displayName: 'Critique', name: 'critical' },
    ];

    this.currentStat = this.stats[0];
  }

  public onStatChange(event: MatButtonToggleChange): void {
    this.currentStat = this.stats.filter((s) => s.name === event.value)[0];
  }

  public isChecked(stat: IStat): boolean {
    return stat.name === this.currentStat.name;
  }

  public getEnhancementNameToDisplay(enhancement: IEnhancement): string {
    switch (this.currentStat.name) {
      case 'accuracy':
        return enhancement.accuracyName;
      case 'alacrity':
        return enhancement.alacrityName;
      case 'critical':
        return enhancement.criticalName;
      default:
        return 'Erreur !';
    }
  }

  public close(): void {
    this.dialogReference.close();
  }
}
