import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseURL = 'http://localhost:5000/api/v1/Evento'; // correta
  //baseURL = 'https://localhost:44366/api/v1/Evento';
  //tokenHeader: HttpHeaders;

  constructor(private http: HttpClient) {
    // this.tokenHeader = new HttpHeaders({ 'Authorization': `Bearer ${localStorage.getItem('token')}` });
  }

  // tslint:disable-next-line:typedef
  getAllEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>('${this.baseURL}/getByTema/${tema}');
  }

  getEventoById(id: number): Observable<Evento[]> {
    return this.http.get<Evento[]>('${this.baseURL}/${id}');
  }

  postUpload(file: File, name: string) {
    const fileToUplaod = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUplaod, name);

    return this.http.post(`${this.baseURL}/upload`, formData);
  }

  postEvento(evento: Evento) {
    return this.http.post(this.baseURL, evento);
  }

  putEvento(evento: Evento) {
    console.log('put');
    console.log(evento.nome);
    console.log(evento.id);
    console.log(`${this.baseURL}/${evento.id}`);
    return this.http.put(`${this.baseURL}/${evento.id}`, evento);
  }

  deleteEvento(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
