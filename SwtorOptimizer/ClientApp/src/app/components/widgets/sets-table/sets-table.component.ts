import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { IGearPieceSet } from '../../../models/IGearPieceSet';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EnhancementSetsService } from '../../../services/enhancement-sets.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-sets-table',
  templateUrl: './sets-table.component.html',
  styleUrls: ['./sets-table.component.scss'],
})
export class SetsTableComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'setName', 'power', 'endurance', 'details'];
  public dataSource: MatTableDataSource<IGearPieceSet> = new MatTableDataSource();
  public selectedSet: IGearPieceSet | null;
  public setsNumber = 0;
  public minEnhancement = 1;
  public maxEnhancement = 1;
  public selectedNbEnhancement = 1;

  @Input()
  public taskId: number;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private service: EnhancementSetsService) {}

  public ngOnInit(): void {
    this.getData();
  }

  private getData(): void {
    if (this.taskId != null) {
      this.service.getEnhancementSetsByTaskId(this.taskId).subscribe((e) => {
        this.initDataSource(e);
      });
    }
  }

  public showSetDetails(enhancementSet: IGearPieceSet): void {
    this.selectedSet = enhancementSet;
  }

  private initDataSource(enhancementSets: IGearPieceSet[]): void {
    this.setsNumber = enhancementSets.length;
    this.dataSource = new MatTableDataSource(enhancementSets);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    const max = Math.max.apply(Math, enhancementSets.map(function(o) {return o.gearPieceCount}));
    this.minEnhancement = Math.min.apply(Math, enhancementSets.map(function(o) {return o.gearPieceCount}));
    this.maxEnhancement = max;
    this.selectedNbEnhancement = max;
  }
}
