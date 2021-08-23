import { Component, Input, OnInit } from '@angular/core';
import { Interprete } from 'src/app/models/Interprete';
import { InterpreteService } from 'src/app/services/interprete.service';

@Component({
  selector: 'app-musica-interpretes',
  templateUrl: './musica-interpretes.component.html',
  styleUrls: ['./musica-interpretes.component.css']
})
export class MusicaInterpretesComponent implements OnInit {

  @Input() musicaId = 0; 
  
  public interpretes: Interprete[];
  
  constructor(private interpreteService: InterpreteService) { }

  ngOnInit() {
    this.carregarInterpretes();    
  }

  carregarInterpretes() {
    this.interpreteService.getByMusicaId(this.musicaId).subscribe(
      (interpretes: Interprete[]) => {
        this.interpretes = interpretes;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }  

}
