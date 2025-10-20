import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './auth.service';

export const authGuard: CanActivateFn = (route, state) => {

  const auth = inject(AuthService);
  const router = inject(Router);
  const status =  auth.isUserLoggedIn();
  if(!status)
    return router.parseUrl('/login');

  return true;
};
