import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { IEnhancementSet } from '../../../models/IEnhancementSet';
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
  public dataSource: MatTableDataSource<IEnhancementSet> = new MatTableDataSource();
  public selectedSet: IEnhancementSet | null;

  @Input()
  public threshold: number;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private service: EnhancementSetsService) {}

  public ngOnInit(): void {
    this.getData();
  }

  private getData(): void {
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

  public showSetDetails(enhancementSet: IEnhancementSet): void {
    this.selectedSet = enhancementSet;
  }

  private initDataSource(enhancementSets: IEnhancementSet[]): void {
    this.dataSource = new MatTableDataSource(enhancementSets);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
}
