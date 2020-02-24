import { Component, Input, Output, EventEmitter } from "@angular/core";
import { UpdateableItem, IIdentity, ChildCollection } from "../../models/child-collection";

@Component({
    selector: 'updateable-item',
    templateUrl: './updateable-item.component.html'
})
export class UpdateableItemComponent {
    @Input('item')
    public Item: UpdateableItem<IIdentity>;
    @Output() removed: EventEmitter<number> = new EventEmitter();
    constructor() {
    }

    remove(id: number): void {
        this.removed.emit(id);
    }
}