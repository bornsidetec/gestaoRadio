import { Component, Input, OnInit } from '@angular/core';
import { Album } from 'src/app/models/Album';
import { AlbumService } from 'src/app/services/album.service';

@Component({
  selector: 'app-interprete-albuns',
  templateUrl: './interprete-albuns.component.html',
  styleUrls: ['./interprete-albuns.component.css']
})
export class InterpreteAlbunsComponent implements OnInit {

  @Input() interpreteId = 0;

  public albuns: Album[];

  constructor(private albumService: AlbumService) {
  }

  ngOnInit() {
    this.carregarAlbuns()
  }

  carregarAlbuns() {
    this.albumService.getByInterpreteId(this.interpreteId).subscribe(
      (album: Album[]) => {
        this.albuns = album;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

}
