export class Request {
    id: number;
    description : String;
    columns!: any;
    row!: any;
    hourOfStart!: Date;

    constructor(id:number,description:String){
        this.id=id;
        this.description=description;
    }
}