import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatButtonToggleChange } from '@angular/material/button-toggle';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IEnhancement } from 'src/app/models/IEnhancement';
import { IEnhancementSet } from 'src/app/models/IEnhancementSet';
import { IStat } from 'src/app/models/IStat';

@Component({
  selector: 'app-set-details',
  templateUrl: './set-details.component.html',
  styleUrls: ['./set-details.component.scss'],
})
export class SetDetailsComponent implements OnInit {
  public dataSource: MatTableDataSource<IEnhancement> = new MatTableDataSource();
  public displayedColumns: string[] = ['name', 'power', 'endurance', 'tertiary'];
  @Input() public selectedSet: IEnhancementSet;
  public stats: IStat[];
  public currentStat: IStat;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  constructor() {}

  public ngOnInit(): void {
    this.stats = [
      { displayName: 'Précision', name: 'accuracy' },
      { displayName: 'Alacrité', name: 'alacrity' },
      { displayName: 'Critique', name: 'critical' },
    ];
    this.currentStat = this.stats[0];

    this.initDataSource();
  }

  private initDataSource(): void {
    const data: IEnhancement[] = [...this.selectedSet.enhancements];
    this.dataSource = new MatTableDataSource(data);
    this.dataSource.sort = this.sort;
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
        return `${enhancement.name} ${enhancement.accuracyName}`;
      case 'alacrity':
        return `${enhancement.name} ${enhancement.alacrityName}`;
      case 'critical':
        return `${enhancement.name} ${enhancement.criticalName}`;
      default:
        return 'Erreur !';
    }
  }
}
