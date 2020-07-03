import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  baseURL = 'https://localhost:44366/api/v1/evento';

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line:typedef
  getEvento(){
    return this.http.get(this.baseURL);
  }
}
