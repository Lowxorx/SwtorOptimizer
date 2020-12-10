import { Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IGearPiece } from 'src/app/models/IGearPiece';
import { IGearSet } from 'src/app/models/IGearSet';

@Component({
  selector: 'app-set-details',
  templateUrl: './set-details.component.html',
  styleUrls: ['./set-details.component.scss'],
})
export class SetDetailsComponent implements OnInit, OnChanges {
  public dataSource: MatTableDataSource<IGearPiece> = new MatTableDataSource();
  public displayedColumns: string[] = ['name', 'power', 'endurance', 'tertiary'];
  @Input() public selectedSet: IGearSet;

  @ViewChild(MatSort, { static: true })
  public sort: MatSort;

  constructor() {}

  public ngOnInit(): void {
    this.initDataSource();
  }

  public ngOnChanges(changes: SimpleChanges) {
    this.initDataSource();
  }

  private initDataSource(): void {
    const data: IGearPiece[] = [...this.selectedSet.gearPieces];
    this.dataSource = new MatTableDataSource(data);
    this.dataSource.sort = this.sort;
  }
}
