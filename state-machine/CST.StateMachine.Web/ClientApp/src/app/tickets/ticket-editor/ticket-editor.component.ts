import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TicketEditorDTO } from '../models/ticket-editor.dto';
import { TicketService } from '../ticket.service';
import { ISelectable } from '../models/state.dto';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'ticket-editor',
  templateUrl: './ticket-editor.component.html',
  styleUrls: [
    './ticket-editor.component.css'
  ]
})
export class TicketEditorComponent implements OnInit {
  ngOnInit(): void {
    this.route
        .paramMap
        .subscribe(params => {
          const ticketId = parseInt(params.get('ticketId'), 10);
          return this.ticketService
              .GetTicket(ticketId)
              .subscribe(ticket => {
                this.ticket = ticket;
              });
        });
    this.ticketService
        .GetTransitions()
        .subscribe(transitions => {
          this.ticketTransitions = transitions
        })
  }

  transitionId?: number;
  ticket: TicketEditorDTO = new TicketEditorDTO();
  ticketTransitions: Array<ISelectable>;

  constructor(
    private route: ActivatedRoute,
    private ticketService: TicketService){

    }

  public onSubmit(ticketEditorForm: NgForm) : void {
    this.ticketService
      .UpdateTicket(this.ticket, this.transitionId)
      .subscribe(updatedTicket => {
        this.ticket = updatedTicket;
        ticketEditorForm.reset();
      });
  }
}
