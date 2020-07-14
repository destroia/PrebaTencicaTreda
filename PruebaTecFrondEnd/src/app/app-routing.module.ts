import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CrudTComponent } from './crud-t/crud-t.component';
import { TiendaComponent } from './tienda/tienda.component';


const routes: Routes = [
  { path: '', component: CrudTComponent },
  { path: 'Tienda', component: TiendaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
