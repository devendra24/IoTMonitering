import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TelemetryService {
  private hubConnection!: signalR.HubConnection;
  private telemetrySubject = new BehaviorSubject<any[]>([]);
  telemetry$ = this.telemetrySubject.asObservable();

  
  constructor() { }

  startConnection(token: string, deviceId: number) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/hubs/telemetry',{accessTokenFactory: ()=> token})
      .build();

    this.hubConnection
      .start()
      .then(()=>{
        console.log('signalR Connected');
        this.joinDeviceGroup(deviceId);
      })
  }

  joinDeviceGroup(deviceId: number) {
    this.hubConnection.invoke('joinDeviceGroup',deviceId)
      .catch(err => console.error(err));
  }

  stopConnection() {
    this.hubConnection.stop();
  }
}
