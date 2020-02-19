export interface IIdentity {
    Id: number;
}

export enum UpdateableItemStateEnum {
    Unchanged = 0,
    Added = 1,
    Deleted = 2,
    Modified = 3
}

export class UpdateableItem<TItem extends IIdentity> {
    State: UpdateableItemStateEnum;
    Item: TItem;

    private constructor(item: TItem) {
        this.Item = item;
    }

    public static added<TItem extends IIdentity>(item: TItem): UpdateableItem<TItem> {
        return new UpdateableItem<TItem>(item);
    }
}

export class ChildCollection<TItem extends IIdentity> {
    Items: Array<UpdateableItem<TItem>>;

    add(item: TItem): void {
        let existingItem = this.Items
            .find(uItem => uItem.Item.Id === item.Id);
        if (existingItem) {
            return;
        }
        
        this.Items.push(UpdateableItem.added<TItem>(item));
    }

    remove(id: number): void {
        let existingItem = this.Items.find(uItem => uItem.Item.Id === id);
        if (!existingItem){
            return;
        }

        switch (existingItem.State){
            case UpdateableItemStateEnum.Modified:
            case UpdateableItemStateEnum.Unchanged:
                existingItem.State = UpdateableItemStateEnum.Deleted;
                break;
            case UpdateableItemStateEnum.Added:
                this.Items = this.Items.filter(i => i.Item.Id !== id);
                break;
            default:
                break;
        }
    }
}