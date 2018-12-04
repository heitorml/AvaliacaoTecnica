import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PaginaAvaliacaoComponent } from './pages/pagina-avalicao/pagina-avaliacao.component';

const routes: Routes = [
  { path: 'avaliacao', component: PaginaAvaliacaoComponent },
  { path: '**', redirectTo: 'avaliacao', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
