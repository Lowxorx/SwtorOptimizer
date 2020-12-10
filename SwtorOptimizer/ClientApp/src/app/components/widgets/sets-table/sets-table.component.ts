import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { IGearSet } from '../../../models/IGearSet';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GearSetsService } from '../../../services/gear-sets.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-sets-table',
  templateUrl: './sets-table.component.html',
  styleUrls: ['./sets-table.component.scss'],
})
export class SetsTableComponent implements OnInit {
  public displayedColumns: string[] = ['threshold', 'setName', 'power', 'endurance', 'details'];
  public dataSource: MatTableDataSource<IGearSet> = new MatTableDataSource();
  public selectedSet: IGearSet | null;
  public setsNumber = 0;

  @Input()
  public taskId: number;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private service: GearSetsService) {}

  public ngOnInit(): void {
    this.getData();
  }

  private getData(): void {
    if (this.taskId != null) {
      this.service.getGearSetsByTaskId(this.taskId).subscribe((e) => {
        this.initDataSource(e);
      });
    }
  }

  public showSetDetails(enhancementSet: IGearSet): void {
    this.selectedSet = enhancementSet;
  }

  private initDataSource(enhancementSets: IGearSet[]): void {
    this.setsNumber = enhancementSets.length;
    this.dataSource = new MatTableDataSource(enhancementSets);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
}
