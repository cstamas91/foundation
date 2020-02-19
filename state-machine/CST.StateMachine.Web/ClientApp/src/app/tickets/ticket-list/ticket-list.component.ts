import { Component, OnInit } from '@angular/core';
import { TicketListDTO } from '../models/ticket-list.dto';
import { TicketService } from '../ticket.service';

@Component({
  selector: 'ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: [
    './ticket-list.component.css'
  ]
})
export class TicketListComponent implements OnInit {
    ngOnInit(): void {
        this.ticketService
        .GetTickets({
          
        })
        .subscribe(result => this.ticketList = result);
    }
    ticketList: Array<TicketListDTO>;

    constructor(private ticketService: TicketService){

    }
}
