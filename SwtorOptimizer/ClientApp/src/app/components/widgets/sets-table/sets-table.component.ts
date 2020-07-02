import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { IEnhancementSet } from '../../../models/IEnhancementSet';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EnhancementSetsService } from '../../../services/enhancement-sets.service';

@Component({
  selector: 'app-sets-table',
  templateUrl: './sets-table.component.html',
  styleUrls: ['./sets-table.component.scss'],
})
export class SetsTableComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'setName', 'power'];
  public dataSource: MatTableDataSource<IEnhancementSet> = new MatTableDataSource();

  @Input()
  public threshold: number;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  constructor(private service: EnhancementSetsService) { }

  public ngOnInit() {
    if (this.threshold != null) {
      this.service.getEnhancementSetsForThreshold(this.threshold).subscribe(e => {
        this.initDataSource(e);
      });
    } else {
      this.service.getEnhancementSets().subscribe(e => {
        this.initDataSource(e);
      });
    }
  }

  private initDataSource(enhancementSets: IEnhancementSet[]): void {
    this.dataSource = new MatTableDataSource(enhancementSets);
    this.dataSource.sort = this.sort;
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
