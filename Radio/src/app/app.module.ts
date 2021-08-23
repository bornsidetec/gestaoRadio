import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxBootstrapIconsModule, allIcons } from 'ngx-bootstrap-icons';
import { TituloComponent } from './components/shared/titulo/titulo.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/shared/perfil/perfil.component';
import { AlbunsComponent } from './components/albuns/albuns.component';
import { AlbumInterpretesComponent } from './components/albuns/album-interpretes/album-interpretes.component';
import { InterpretesComponent } from './components/interpretes/interpretes.component';
import { MusicasComponent } from './components/musicas/musicas.component';
import { MusicaInterpretesComponent } from './components/musicas/musica-interpretes/musica-interpretes.component';
import { AlbumImagemComponent } from './components/albuns/album-imagem/album-imagem.component';
import { InterpreteMusicasComponent } from './components/interpretes/interprete-musicas/interprete-musicas.component';
import { InterpreteAlbunsComponent } from './components/interpretes/interprete-albuns/interprete-albuns.component';

@NgModule({
  declarations: [	
    AppComponent,
    AlbunsComponent,
    AlbumImagemComponent,
    AlbumInterpretesComponent,
    MusicasComponent,
    MusicaInterpretesComponent,
    InterpretesComponent,
    InterpreteMusicasComponent,
    InterpreteAlbunsComponent,    
    PerfilComponent,
    DashboardComponent,
    NavComponent,
    TituloComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    HttpClientModule,
    NgxBootstrapIconsModule.pick(allIcons),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
