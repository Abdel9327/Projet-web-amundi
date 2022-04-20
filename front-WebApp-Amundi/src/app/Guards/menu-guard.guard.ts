import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentificationComponent } from '../identification/identification.component';

@Injectable({
  providedIn: 'root'
})
export class MenuGuardGuard implements CanActivate {
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if(IdentificationComponent.loginMake==true){
        IdentificationComponent.loginMake=false
        return true;
      }
    return false;
  }
  
}
