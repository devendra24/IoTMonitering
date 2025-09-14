import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DeviceServiceService {
  private baseUrl = 'https://localhost:5001/api/devices';

  constructor(private http: HttpClient) { }

  private getHeaders(){
    const token = localStorage.getItem('jwt');
    return {headers: new HttpHeaders({Authorization : `Bearer ${token}`})};
  }

  getDevices() {
    return this.http.get(this.baseUrl, this.getHeaders());
  }

  createDevice(device: any) {
    return this.http.post(this.baseUrl, device, this.getHeaders());
  }

  updateDevice(id: number, device: any) {
    return this.http.put(`${this.baseUrl}/${id}`, device, this.getHeaders());
  }

  deleteDevice(id: number) {
    return this.http.delete(`${this.baseUrl}/${id}`, this.getHeaders());
  }
}
