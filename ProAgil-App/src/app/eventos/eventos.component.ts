import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {  ptBrLocale } from 'ngx-bootstrap/locale';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  dataEvento: string;
  eventos: Evento[];
  imagemLargura = 50;
  imagemAltura = 2;
  mostrarImagem = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;

  file: File;
  _filtroLista: string;

  constructor(
    private eventoService: EventoService
  , private modalService: BsModalService
  ) {  }

  get filtroLista(): string{
    return this._filtroLista;
  }

  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: Evento[];

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.validation();
    this.getEventos();
  }

  // filtrarEventos(filtrarPor: string): Evento[] {
  //   filtrarPor = filtrarPor.toLocaleLowerCase();
  //   return this.eventos.filter(
  //     evento => evento.nome.toLocaleLowerCase().indexOf(filtrarPor) !==  -1
  //   );
  // }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(evento => { 
        return evento.nome.toLocaleLowerCase().includes(filtrarPor)
    });
  }

  validation() {
    this.registerForm = new FormGroup({
      local: new FormControl('', Validators.required),
      dataEvento: new FormControl('', Validators.required),
      nome: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
      qtdPessoas: new FormControl('', [Validators.required, Validators.max(120000)]),
      imagemURL: new FormControl('', Validators.required),
      telefone: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email])
    });
  }

  onFileChange(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      this.file = event.target.files;
      console.log(this.file);
    }
  }

  salvarAlteracao(){

  }

  alternarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  getEventos() {
    this.eventoService.getAllEvento().subscribe(
    (_eventos: Evento[]) => {
      this.eventos = _eventos;
      console.log(_eventos);
    }, error => {
        console.log(error);
    });
  }
}
