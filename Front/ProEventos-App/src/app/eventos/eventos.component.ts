import { HttpClient } from '@angular/common/http';
import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements  OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  showImage: boolean = false;

  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    console.log(this.eventosFiltrados);
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public hideImage(): void {
    this.showImage = !this.showImage;
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get("https://localhost:5001/api/eventos").subscribe(
     {
      next: (response: any) => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        console.log(error);
      }
     }
    );
  }
}
