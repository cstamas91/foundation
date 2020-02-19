import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { TicketListDTO } from './models/ticket-list.dto';
import { TicketEditorDTO } from './models/ticket-editor.dto';
import { NewTicketDTO } from './models/new-ticket.dto';
import { TicketListFilter } from './models/ticket-list-filter';
import { TicketHttpService } from './ticket-http.service';
import { StateDTO, TransitionDTO } from './models/state.dto';

@Injectable({
    providedIn: 'root'
})
export class TicketService {
    
    constructor(private ticketHttp: TicketHttpService){
        
    }

    public GetTransitions(id?: number) : Observable<Array<TransitionDTO>> {
        let queryData = null;
        if (id){
            queryData = ({
                currentStateId: id
            });
        } 
        return this.ticketHttp.get<Array<TransitionDTO>>('/transitions', queryData);
    }

    public CreateTicket(ticket: NewTicketDTO) : Observable<TicketEditorDTO> {
        return this.ticketHttp.put<TicketEditorDTO>('', ticket);
    }

    public GetTickets(filter: TicketListFilter) : Observable<Array<TicketListDTO>> {
        return this.ticketHttp.get<Array<TicketListDTO>>('', filter);
    }

    public GetTicket(id: number) : Observable<TicketEditorDTO> {
        return this.ticketHttp.get<TicketEditorDTO>(`?id=${id}`);
    }
    
    public GetProxy() : Observable<NewTicketDTO> {
        return this.ticketHttp.get<NewTicketDTO>('/proxy');
    }

    public UpdateTicket(ticket: TicketEditorDTO, transitionId?: number) : Observable<TicketEditorDTO> {
        if (transitionId){
            return this.ticketHttp.post(`?transitionId=${transitionId}`, ticket);
        }
        
        return this.ticketHttp.post('', ticket);
    }
}