import { CommitDTO } from "./commit.dto";

export class TicketEditorDTO {
    Id: number;
    StateId: number;
    Description: string;
    Commits: Array<CommitDTO>;

    constructor(){
        this.Id = 0;
        this.StateId = 0;
        this.Description = 'Write something';
        this.Commits = new Array<CommitDTO>();
    }
}