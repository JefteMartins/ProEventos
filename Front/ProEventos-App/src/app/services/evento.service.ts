import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  // { Já adicionado no app.module.ts
  //   providedIn: 'root',
  // }
)
export class EventoService {
  baseURL = 'https://localhost:5001/api/eventos';
  constructor(private http: HttpClient) {}

  getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
  }

  getEventosId(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
