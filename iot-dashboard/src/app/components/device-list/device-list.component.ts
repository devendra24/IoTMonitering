import { Component, OnInit } from '@angular/core';
import { TelemetryDashboardComponent } from "../telemetry-dashboard/telemetry-dashboard.component";
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { DeviceService } from '../../services/device.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-device-list',
  standalone: true,
  imports: [
  CommonModule,
  MatToolbarModule,
  MatButtonModule,
  MatListModule,
  TelemetryDashboardComponent
  ],
  templateUrl: './device-list.component.html',
  styleUrl: './device-list.component.scss'
})
export class DeviceListComponent implements OnInit {

  devices: any[] = [];

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.devices = this.route.snapshot.data['devicesData'];
  }
  deleteDevice(arg0: any) {
  throw new Error('Method not implemented.');
  }
  editDevice(_t6: any) {
  throw new Error('Method not implemented.');
  }
  openAddDialog() {
  throw new Error('Method not implemented.');
  }

}
