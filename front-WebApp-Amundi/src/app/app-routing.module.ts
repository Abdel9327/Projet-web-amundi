import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuGuardGuard } from './Guards/menu-guard.guard';
import { IdentificationComponent } from './identification/identification.component';
import { MenuComponent } from './menu/menu.component';

const routes: Routes = [
  {path:'login',component:IdentificationComponent},
  {path:'menu/:account',component: MenuComponent,canActivate:[MenuGuardGuard]}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
