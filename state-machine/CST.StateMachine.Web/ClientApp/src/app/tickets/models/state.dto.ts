export interface ISelectable {
    Id: number;
    Name: string;
}

export class BaseSelectable implements ISelectable {
    Id: number;
    Name: string;
}

export class StateDTO extends BaseSelectable {

}

export class TransitionDTO extends BaseSelectable {
    
}