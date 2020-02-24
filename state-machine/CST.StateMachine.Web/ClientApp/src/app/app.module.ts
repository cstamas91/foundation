import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { TicketListComponent } from './tickets/ticket-list/ticket-list.component';
import { TicketService } from './tickets/ticket.service';
import { TicketEditorComponent } from './tickets/ticket-editor/ticket-editor.component';
import { NewTicketComponent } from './tickets/new-ticket/new-ticket.component';
import { TicketHttpService } from './tickets/ticket-http.service';
import { ChildCollectionComponent } from './common/components/child-collection/child-collection.component';
import { UpdateableItemComponent } from './common/components/child-collection/updateable-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TicketListComponent,
    TicketEditorComponent,
    NewTicketComponent,
    ChildCollectionComponent,
    UpdateableItemComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'tickets', component: TicketListComponent, pathMatch: 'full' },
      { path: 'ticket/:ticketId', component: TicketEditorComponent },
      { path: 'new-ticket', component: NewTicketComponent }
    ])
  ],
  providers: [
    TicketService,
    TicketHttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
