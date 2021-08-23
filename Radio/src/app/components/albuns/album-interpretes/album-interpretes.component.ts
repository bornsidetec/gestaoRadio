import { Component, Input, OnInit } from '@angular/core';
import { Interprete } from 'src/app/models/Interprete';
import { InterpreteService } from 'src/app/services/interprete.service';

@Component({
  selector: 'app-album-interpretes',
  templateUrl: './album-interpretes.component.html',
  styleUrls: ['./album-interpretes.component.css']
})
export class AlbumInterpretesComponent implements OnInit {

  @Input() albumId = 0; 
  
  public interpretes: Interprete[];
  
  constructor(private interpreteService: InterpreteService) { }

  ngOnInit() {
    this.carregarInterpretes();    
  }

  carregarInterpretes() {
    this.interpreteService.getByAlbumId(this.albumId).subscribe(
      (interpretes: Interprete[]) => {
        this.interpretes = interpretes;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }  

}
