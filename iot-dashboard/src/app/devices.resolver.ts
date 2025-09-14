import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { DeviceService } from './services/device.service';
import { catchError, of } from 'rxjs';

export const devicesResolver: ResolveFn<any[]> = (route, state) => {
  const deviceService = inject(DeviceService);
  return deviceService.getDevices().pipe(
      catchError(err => {
        console.error(err);
        return of([]); // return empty array if API fails
      })
    );
};
