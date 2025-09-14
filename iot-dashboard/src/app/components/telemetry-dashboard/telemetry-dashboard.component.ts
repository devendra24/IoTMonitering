import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { TelemetryService } from '../../services/telemetry.service';
import { Subscription } from 'rxjs';
import { ChartData, ChartOptions } from 'chart.js';
import {NgChartsModule} from 'ng2-charts';

@Component({
  selector: 'app-telemetry-dashboard',
  standalone: true,
  imports: [NgChartsModule],
  templateUrl: './telemetry-dashboard.component.html',
  styleUrl: './telemetry-dashboard.component.scss'
})
export class TelemetryDashboardComponent implements OnInit, OnDestroy{
  
  @Input() deviceId!: number;
  subscription!: Subscription;
  telemetryData: any[] = [];

  chartData:ChartData<'line'> = {
    labels:[],
    datasets:[
      { label: 'Temperature', data: [], borderColor: 'red', fill: false },
      { label: 'Humidity', data: [], borderColor: 'blue', fill: false }
    ]
  }

  chartOptions: ChartOptions<'line'> = {
    responsive: true
  };

  constructor(private telemetryService: TelemetryService ) {}
  ngOnInit(): void {
    const token = localStorage.getItem('jwt')??"unknown";

    this.telemetryService.startConnection(token,this.deviceId);

    this.subscription = this.telemetryService.telemetry$.subscribe(data =>{
      this.telemetryData = data;
      this.updateChart();
    })
  }
  updateChart() {
    this.chartData.labels = this.telemetryData.map(t => new Date(t.timestamp).toLocaleTimeString());
    this.chartData.datasets[0].data = this.telemetryData.map(t => t.temperature);
    this.chartData.datasets[1].data = this.telemetryData.map(t => t.humidity);
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.telemetryService.stopConnection();
  }

}
