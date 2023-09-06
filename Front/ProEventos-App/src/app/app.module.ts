import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { NavComponent } from './nav/nav.component';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { EventoService } from './services/evento.service';
@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
      NavComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CollapseModule.forRoot(),
    AccordionModule.forRoot()
  ],
  providers: [EventoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
