import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements  OnInit {

  public eventos: any = [
    {
      Tema: 'Angular 11',
      Local: 'Belo Horizonte'
    },
    {
      Tema: 'Angular 12',
      Local: 'Teste'
    },
    {
      Tema: 'Angular 13',
      Local: 'Teste 2'
    },
  ]

  constructor() { }

  ngOnInit(): void {

  }

}
