import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})

export class EventosComponent implements OnInit {
  eventosFiltrados: Evento[];
  eventos: Evento[];

  evento: Evento;
  modoSalvar = 'post';

  imagemLargura = 50;
  imagemAltura = 2;
  mostrarImagem = false;
  registerForm: FormGroup;
  bodyDeletarEvento = '';

  _filtroLista: string;

  file: File;

  dataEvento: string;
  dataAtual: string;

  constructor(
    private eventoService: EventoService
  , private modalService: BsModalService
  , private fb: FormBuilder
  , private localeservice: BsLocaleService
  , private toastr: ToastrService
  )
  {
    this.localeservice.use('pt-br');
  }

  get filtroLista(): string{
    return this._filtroLista;
  }

  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  editarEvento(evento: Evento, template: any){
    console.log(evento);
    this.modoSalvar = 'put';
    this.openModal(template);
    this.evento = evento;
    this.registerForm.patchValue(evento);
  }

  novoEvento(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  excluirEvento(evento: Evento, template: any) {
    //template.show();
    this.openModal(template);
    this.evento = evento;
    this.bodyDeletarEvento = `Tem certeza que deseja excluir o Evento: ${evento.nome}, Código: ${evento.id}`;
  }

  confirmeDelete(template: any) {
    this.eventoService.deleteEvento(this.evento.id).subscribe(
      () => {
          template.hide();
          this.getEventos();
          this.toastr.success('Deletado com Sucesso');
        }, error => {
          this.toastr.error('Erro ao tentar Deletar');
          console.log(error);
        }
    );
  }

  openModal(template: any){
    this.registerForm.reset();
    template.show(template);
  }

  ngOnInit() {
    this.validation();
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.nome.toLocaleLowerCase().indexOf(filtrarPor) !==  -1
    );
  }

  // filtrarEventos(filtrarPor: string): Evento[] {
  //   filtrarPor = filtrarPor.toLocaleLowerCase();
  //   return this.eventos.filter(evento => { 
  //       return evento.nome.toLocaleLowerCase().includes(filtrarPor)
  //   });
  // }

  validation() {
    this.registerForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      imagemURL: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onFileChange(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      this.file = event.target.files;
      console.log(this.file);
    }
  }

  salvarAlteracao(template: any){
    console.log(this.modoSalvar);
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post'){
        this.evento = Object.assign({}, this.registerForm.value);
        console.log(template);
        this.eventoService.postEvento(this.evento).subscribe(
          (novoEvento: Evento) => {
            console.log(novoEvento);
            template.hide();
            this.getEventos();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error(`Erro ao Inserir: ${error}`);
          }
        );
      } else {
        this.evento = Object.assign({id: this.evento.id}, this.registerForm.value);
        //console.log(template);
        this.eventoService.putEvento(this.evento).subscribe(
          () => {
            //console.log(novoEvento);
            template.hide();
            this.getEventos();
            this.toastr.success('Inserido com Sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error(`Erro ao Inserir: ${error}`);
          }
        );
      }
    }
  }

  alternarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  getEventos() {
    this.dataAtual = new Date().getMilliseconds().toString();

    this.eventoService.getAllEvento().subscribe(
    (_eventos: Evento[]) => {
      this.eventos = _eventos;
      this.eventosFiltrados = this.eventos;
      console.log(_eventos);
    }, error => {
      this.toastr.error(`Erro ao tentar Carregar eventos: ${error}`);
      console.log(error);
    });
  }
}
