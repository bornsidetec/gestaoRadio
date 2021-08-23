import { Component, Input, OnInit } from '@angular/core';
import { Musica } from 'src/app/models/Musica';
import { MusicaService } from 'src/app/services/musica.service';

@Component({
  selector: 'app-interprete-musicas',
  templateUrl: './interprete-musicas.component.html',
  styleUrls: ['./interprete-musicas.component.css']
})
export class InterpreteMusicasComponent implements OnInit {

  @Input() interpreteId = 0;

  public musicas: Musica[];

  constructor(private musicaService: MusicaService) {

  }

  ngOnInit() {
    this.carregarMusicas()
  }

  carregarMusicas() {
    this.musicaService.getByInterpreteId(this.interpreteId).subscribe(
      (musica: Musica[]) => {
        this.musicas = musica;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }
 
}
