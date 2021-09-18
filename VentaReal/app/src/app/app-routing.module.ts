import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClienteComponent } from './cliente/cliente.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "cliente", component: ClienteComponent},
  { path: "user", component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
