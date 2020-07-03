import { Component, OnInit } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';

import { from } from 'rxjs';
@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _filtroLista: string;

  get filtroLista(): string{
    return this._filtroLista;
  }

  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: Evento[];

  eventos: Evento[];
  imagemLargura = 50;
  imagemAltura = 2;
  mostrarImagem = false;

  constructor(private eventoService: EventoService) {  }

  ngOnInit() {
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
