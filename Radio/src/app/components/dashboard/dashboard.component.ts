import { Component, OnInit } from '@angular/core';
import { Album } from 'src/app/models/Album';
import { Interprete } from 'src/app/models/Interprete';
import { Musica } from 'src/app/models/Musica';
import { AlbumService } from 'src/app/services/album.service';
import { InterpreteService } from 'src/app/services/interprete.service';
import { MusicaService } from 'src/app/services/musica.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public titulo = 'Dashboard'
  public musicas: Musica[];
  public albuns: Album[];
  public interpretes: Interprete[]

  constructor(private musicaService: MusicaService,
    private albumService: AlbumService,
    private interpreteService: InterpreteService) { }

  ngOnInit() {
    this.carregarMusicas(),
    this.carregarAlbuns();
    this.carregarInterpretes();
  }

  carregarMusicas() {
    this.musicaService.getAll().subscribe(
      (musicas: Musica[]) => {
        this.musicas = musicas;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  carregarAlbuns() {
    this.albumService.getAll().subscribe(
      (albuns: Album[]) => {
        this.albuns = albuns;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  carregarInterpretes() {
    this.interpreteService.getAll().subscribe(
      (interpretes: Interprete[]) => {
        this.interpretes = interpretes;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }


}
