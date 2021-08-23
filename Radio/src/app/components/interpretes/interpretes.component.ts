import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Interprete } from 'src/app/models/Interprete';
import { InterpreteService } from 'src/app/services/interprete.service';

@Component({
  selector: 'app-interpretes',
  templateUrl: './interpretes.component.html',
  styleUrls: ['./interpretes.component.css']
})
export class InterpretesComponent implements OnInit {

  public modalRef: BsModalRef;
  public interpreteForm: FormGroup;
  public titulo = 'Interpretes';
  public interpreteSelecionado: Interprete;
  public interpretes: Interprete[];
  public interpreteId: number;

  openModal(template: TemplateRef<any>, id: number) {
    this.interpreteId = id;
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private interpreteService: InterpreteService,
  ) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarInterpretes();
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

  criarForm() {
    this.interpreteForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required]
    });
  }

  salvarInterprete(interprete: Interprete) {
    if (interprete.id === 0)
      this.interpreteService.post(interprete).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarInterpretes();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    else
      this.interpreteService.put(interprete).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarInterpretes();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
  }

  interpreteSubmit() {
    this.salvarInterprete(this.interpreteForm.value);
    this.voltar();
  }

  interpreteSelect(interprete: Interprete) {
    this.interpreteSelecionado = interprete;
    this.interpreteForm.patchValue(interprete);
  }

  excluirInterprete(id: number) {
    this.interpreteService.delete(id).subscribe(
      (retorno: any) => {
        console.log(retorno);
        this.carregarInterpretes();
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  incluirInterprete() {
    this.interpreteSelecionado = new Interprete();
    this.interpreteForm.patchValue(this.interpreteSelecionado);
  }

  voltar() {
    this.interpreteSelecionado = null;
  }

}
