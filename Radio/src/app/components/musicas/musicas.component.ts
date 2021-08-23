import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Musica } from 'src/app/models/Musica';
import { MusicaService } from 'src/app/services/musica.service';
import { Interprete } from 'src/app/models/Interprete';
import { InterpreteService } from 'src/app/services/interprete.service';
import { MusicasInterpretes } from 'src/app/models/MusicasInterpretes';

@Component({
  selector: 'app-musicas',
  templateUrl: './musicas.component.html',
  styleUrls: ['./musicas.component.css']
})
export class MusicasComponent implements OnInit {

  public modalRef: BsModalRef;
  public musicaForm: FormGroup;
  public titulo = 'Músicas';
  public musicaSelecionado: Musica;
  public musicaId: number;
  public musicas: Musica[];
  public interpretes: Interprete[];
  public musicasInterpretes: MusicasInterpretes[] = [];

  openModal(template: TemplateRef<any>, id: number) {
    this.musicaId = id;
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private musicaService: MusicaService,
    private interpreteService: InterpreteService) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarMusicas();
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

  criarForm() {
    this.musicaForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      ano: ['', Validators.required],
      estilo: ['', Validators.required],
      tempo: ['', Validators.required],
      musicasInterpretes: [this.musicasInterpretes]
    });
  }

  salvarMusica(musica: Musica) {
    musica.musicasInterpretes = [];
    musica.musicasInterpretes = this.musicaSelecionado.musicasInterpretes;
    if (musica.id === 0)
      this.musicaService.post(musica).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarMusicas();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    else
      this.musicaService.put(musica).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarMusicas();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
  }

  musicaSubmit() {
    this.salvarMusica(this.musicaForm.value);
    this.voltar();
  }

  musicaSelect(musica: Musica) {
    this.musicaSelecionado = musica;
    this.musicasInterpretes = this.musicaSelecionado.musicasInterpretes;
    this.musicaForm.patchValue(musica);
  }

  excluirMusica(id: number) {
    this.musicaService.delete(id).subscribe(
      (retorno: any) => {
        console.log(retorno);
        this.carregarMusicas();
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

  addInterprete(e: any, id: number) {
    if (e.target.checked) {
      this.musicasInterpretes.push({ interpretesId: id });
    }
    else {
      this.musicasInterpretes = this.musicasInterpretes.filter(item => item.interpretesId !== id);
    }
    this.musicaSelecionado.musicasInterpretes = [];
    this.musicaSelecionado.musicasInterpretes = this.musicaSelecionado.musicasInterpretes.concat(this.musicasInterpretes);
  }

  incluirMusica() {
    this.musicaSelecionado = new Musica();
    this.musicaForm.patchValue(this.musicaSelecionado);
    this.musicasInterpretes = [];
  }

  voltar() {
    this.musicaSelecionado = null;
  }

}
