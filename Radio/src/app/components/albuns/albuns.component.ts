import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Album } from 'src/app/models/Album';
import { AlbumService } from 'src/app/services/album.service';
import { Interprete } from 'src/app/models/Interprete';
import { InterpreteService } from 'src/app/services/interprete.service';
import { AlbunsInterpretes } from 'src/app/models/AlbunsInterpretes';

@Component({
  selector: 'app-albuns',
  templateUrl: './albuns.component.html',
  styleUrls: ['./albuns.component.css']
})
export class AlbunsComponent implements OnInit {

  public modalRef: BsModalRef;
  public albumForm: FormGroup;
  public titulo = 'Álbuns';
  public albumSelecionado: Album;
  public albumId: number;
  public albuns: Album[];
  public interpretes: Interprete[];
  public albunsInterpretes: AlbunsInterpretes[] = [];

  openModal(template: TemplateRef<any>, id: number) {
    this.albumId = id
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private albumService: AlbumService,
    private interpreteService: InterpreteService) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarAlbuns();
    this.carregarInterpretes();
  }

  carregarAlbuns() {
    this.albumService.getAll().subscribe(
      (albuns: Album[]) => {
        this.albuns = albuns;
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }

  criarForm() {
    this.albumForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      ano: ['', Validators.required],
      imagem: [''],
      albunsInterpretes: [this.albunsInterpretes]
    });
  }

  salvarAlbum(album: Album) {
    album.albunsInterpretes = [];
    album.albunsInterpretes = this.albumSelecionado.albunsInterpretes;
    if (album.id === 0)
      this.albumService.post(album).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarAlbuns();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    else
      this.albumService.put(album).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarAlbuns();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
  }

  albumSubmit() {
    this.salvarAlbum(this.albumForm.value);
    this.voltar();
  }

  albumSelect(album: Album) {
    this.albumSelecionado = album;
    this.albunsInterpretes = this.albumSelecionado.albunsInterpretes;
    this.albumForm.patchValue(album);
  }

  excluirAlbum(id: number) {
    this.albumService.delete(id).subscribe(
      (retorno: any) => {
        console.log(retorno);
        this.carregarAlbuns();
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
      this.albunsInterpretes.push({ interpretesId: id });
    }
    else {
      this.albunsInterpretes = this.albunsInterpretes.filter(item => item.interpretesId !== id);
    }
    this.albumSelecionado.albunsInterpretes = [];
    this.albumSelecionado.albunsInterpretes = this.albumSelecionado.albunsInterpretes.concat(this.albunsInterpretes);
  }

  incluirAlbum() {
    this.albumSelecionado = new Album();
    this.albumForm.patchValue(this.albumSelecionado);
    this.albunsInterpretes = [];    
  }

  voltar() {
    this.albumSelecionado = null;
  }

}
