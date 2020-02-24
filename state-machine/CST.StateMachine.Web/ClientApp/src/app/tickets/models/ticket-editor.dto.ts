import { CommitDTO } from "./commit.dto";
import { ChildCollection } from "src/app/common/models/child-collection";

export class TicketEditorDTO {
    Id: number;
    StateId: number;
    Description: string;
    RelatedCommits: ChildCollection<CommitDTO>;
    Title: string;

    constructor(){
        this.Id = 0;
        this.StateId = 0;
        this.Description = 'Write something';
        this.RelatedCommits = new ChildCollection<CommitDTO>();
        this.Title = '';
    }
}