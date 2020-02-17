import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TicketEditorDTO } from '../models/ticket-editor.dto';
import { TicketService } from '../ticket.services';

@Component({
  selector: 'ticket-editor',
  templateUrl: './ticket-editor.component.html',
})
export class TicketEditorComponent implements OnInit {
  ngOnInit(): void {
    this.route
        .paramMap
        .subscribe(params => {
          this.ticketService
              .GetTicket(+params.get('ticketId'))
              .subscribe(ticket => {
                this.ticket = ticket;
              });
        });
  }
    ticket: TicketEditorDTO;

    constructor(
      private route: ActivatedRoute,
      private ticketService: TicketService){

      }
}
