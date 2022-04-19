import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IdentificationComponent } from './identification/identification.component';
import { MenuComponent } from './menu/menu.component';

const routes: Routes = [
  {path:'login',component:IdentificationComponent},
  {path:'menu',component: MenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
