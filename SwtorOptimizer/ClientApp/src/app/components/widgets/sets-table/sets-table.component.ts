import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { IEnhancementSet } from '../../../models/IEnhancementSet';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EnhancementSetsService } from '../../../services/enhancement-sets.service';
import { MatButtonToggleChange } from '@angular/material/button-toggle';
import { IStat } from 'src/app/models/IStat';
import { IEnhancement } from 'src/app/models/IEnhancement';

@Component({
  selector: 'app-sets-table',
  templateUrl: './sets-table.component.html',
  styleUrls: ['./sets-table.component.scss'],
})
export class SetsTableComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'setName', 'power', 'endurance', 'details'];
  public dataSource: MatTableDataSource<IEnhancementSet> = new MatTableDataSource();
  public stats: IStat[];
  public currentStat: IStat;
  public selectedSet: IEnhancementSet | null;

  @Input()
  public threshold: number;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  constructor(private service: EnhancementSetsService) {}

  public ngOnInit() {
    this.stats = [
      { displayName: 'Précision', name: 'accuracy' },
      { displayName: 'Alacrité', name: 'alacrity' },
      { displayName: 'Critique', name: 'critical' },
    ];
    this.currentStat = this.stats[0];

    if (this.threshold != null) {
      this.service.getEnhancementSetsForThreshold(this.threshold).subscribe((e) => {
        this.initDataSource(e);
      });
    } else {
      this.service.getEnhancementSets().subscribe((e) => {
        this.initDataSource(e);
      });
    }
  }

  public onStatChange(event: MatButtonToggleChange): void {
    this.currentStat = this.stats.filter((s) => s.name === event.value)[0];
  }

  public isChecked(stat: IStat): boolean {
    return stat.name === this.currentStat.name;
  }

  public getEnhancementDetails(set: IEnhancementSet): string {
    let result = '';

    set.enhancements.forEach((e) => {
      result += `Supérieure 80 ${e.name} ${this.getEnhancementNameToDisplay(e)} | `;
    });

    return result.slice(0, result.length - 2);
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

  public showSetDetails(enhancementSet: IEnhancementSet): void {
    this.selectedSet = enhancementSet;
  }

  private initDataSource(enhancementSets: IEnhancementSet[]): void {
    this.dataSource = new MatTableDataSource(enhancementSets);
    this.dataSource.sort = this.sort;
  }
}
