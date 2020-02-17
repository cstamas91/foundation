import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { TicketListDTO } from './models/ticket-list.dto';
import { TicketEditorDTO } from './models/ticket-editor.dto';
import { CommitDTO } from './models/commit.dto';

@Injectable({
    providedIn: 'root'
})
export class TicketService {
    constructor(private http: HttpClient){

    }

    public GetTickets() : Observable<Array<TicketListDTO>> {
        return of([
            {
                Id: 1,
                State: 'Open'
            },
            {
                Id: 2,
                State: 'Open'
            }
        ]);
    }

    public GetTicket(id: number) : Observable<TicketEditorDTO> {
        if (id === 1 || id === 2){
            return of({
                Id: id,
                StateId: 1,
                Description: 'Hello World',
                Commits: new Array<CommitDTO>()
            });
        }

        return of(null);
    }
}