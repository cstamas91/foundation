import { Component, Input } from "@angular/core";
import { ChildCollection, IIdentity } from "../../models/child-collection";

@Component({
    selector: 'child-collection',
    templateUrl: './child-collection.component.html',
    styleUrls: [
        './child-collection.component.css'
    ]
})
export class ChildCollectionComponent {
    @Input('items')
    public ChildCollection: ChildCollection<IIdentity>;
    constructor (){
        console.log(this.ChildCollection);
    }

    public addNew(item: IIdentity): void {
        this.ChildCollection.add(item);
    }

    public remove(id: number): void {
        this.ChildCollection.remove(id);
    }
}


