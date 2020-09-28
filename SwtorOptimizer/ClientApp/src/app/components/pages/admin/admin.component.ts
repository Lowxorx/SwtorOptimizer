import { Component, OnInit } from '@angular/core';
import { IAppUser } from 'src/app/models/IAppUser';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  public currentUser: string;

  constructor(private adminService: AdminService) {}

  ngOnInit(): void {
    this.adminService.getCurrentUser().subscribe((e) => {
      this.currentUser = e;
    });
  }
}
