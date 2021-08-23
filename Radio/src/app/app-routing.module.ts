import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicasComponent } from './components/musicas/musicas.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/shared/perfil/perfil.component';
import { InterpretesComponent } from './components/interpretes/interpretes.component';
import { AlbunsComponent } from './components/albuns/albuns.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'musicas', component: MusicasComponent },
  { path: 'albuns', component: AlbunsComponent },
  { path: 'interpretes', component:InterpretesComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'perfil', component: PerfilComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
