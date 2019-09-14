import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthGuard } from './auth.guard';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuard extends AuthGuard {
  constructor(auth: AuthService) {
    super(auth);
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      var isAuthenticated = super.canActivate(next, state);
      if(isAuthenticated) {
        console.log(this.auth.isAdmin());
        return this.auth.isAdmin();
      }
      return false;
  }
  
}
