import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-album-imagem',
  templateUrl: './album-imagem.component.html',
  styleUrls: ['./album-imagem.component.css']
})
export class AlbumImagemComponent implements OnInit {

  @Input() imagem = '';

  constructor() { }

  ngOnInit() {
  }

}
