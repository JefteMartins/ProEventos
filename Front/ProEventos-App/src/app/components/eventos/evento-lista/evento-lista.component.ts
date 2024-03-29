import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '@app/models/Evento';
import { EventoService } from '@app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent {
  modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public showImage: boolean = false;
  public eventoId: number = 0;

  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
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
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
    ) { }

  public ngOnInit(): void {
    this.carregarEventos();
    //timeout 500 of the spinner
    this.spinner.show();
  }

  public carregarEventos(): void {
    this.eventoService.getEventos().subscribe(
     {
      next: (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        //timeout 1sec

      },
      error: (error: any) => {
        this.spinner.hide()
        this.toastr.error('Erro ao carregar os eventos!', 'Erro!');
      },
      complete: () => this.spinner.hide()
     }
    );
  }
  openModal(event:any , template: TemplateRef<any>, eventoId: number): void {
    event.stopPropagation();
    this.eventoId = eventoId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();

    this.eventoService.deleteEvento(this.eventoId).subscribe(
      {
        next: (result: any) => {
          if (result.message === 'Deletado'){
            this.toastr.success('Deletado com sucesso!', 'Deletado!');
            this.spinner.hide();
            this.carregarEventos();
          }
        },
        error: (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error(`Erro ao deletar o evento ${this.eventoId}`, 'Erro!');
        },
        complete: () => this.spinner.hide()
      }
    );

    this.toastr.success('Deletado com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }


}
