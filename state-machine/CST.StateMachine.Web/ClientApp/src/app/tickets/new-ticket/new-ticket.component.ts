import { Component, OnInit } from "@angular/core";
import { NewTicketDTO } from "../models/new-ticket.dto";
import { TicketService } from "../ticket.service";
import { Router } from "@angular/router";
import { TicketEditorComponent } from "../ticket-editor/ticket-editor.component";
import { NgForm } from "@angular/forms";

@Component({
    templateUrl: 'new-ticket.component.html',
    styleUrls: [
        './new-ticket.component.css'
    ],
    selector: 'new-ticket'
})
export class NewTicketComponent implements OnInit {
    ngOnInit(): void {
        this.ticketService.GetProxy()
            .subscribe(ticket => {
                this.ticket = ticket;
            });
    }

    public ticket: NewTicketDTO;

    constructor (
        private ticketService : TicketService,
        private router: Router
    ) {
    }

    onSubmit(newTicketForm: NgForm){
        this.ticketService
            .CreateTicket(this.ticket)
            .subscribe(result => {
                this.router.navigate(['/ticket', result.Id]);
            });
    }
}