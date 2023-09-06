import { Component,OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements  OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  showImage: boolean = false;

  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    console.log('filtrados =>', this.eventosFiltrados);
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  public hideImage(): void {
    this.showImage = !this.showImage;
  }
  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe(
     {
      next: (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => console.log(error),
      complete: () => console.log('complete')

     }
    );
  }
}
