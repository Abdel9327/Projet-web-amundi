import { APP_ID, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Request } from '../Models/request';
import { ColDef } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';
import { Account } from '../Models/Account';

@Injectable({
  providedIn: 'root'
})
export class RequestServiceService {
  readonly requestAPIUrl="https://localhost:7185/api/Request";
  

  constructor(private http : HttpClient) {
  }

  async GetDescriptionRequests(account: string) :Promise<Request[]>{

    var description:Request[]=[];
    await this.http.get<Request[]>(this.requestAPIUrl+'/GetAllRequests/'+account).toPromise().then((data)=>description=data!);
    return description!;

  }

 async StartedRequest(request:Request,agGrid: AgGridAngular){

    var column = agGrid.api.getColumnDefs();
    column!.length=0
    var reponseRequest! : String[];

    await this.http.get<string[]>(this.requestAPIUrl+'/startRequest/'+request.id).toPromise().then(data=>{reponseRequest=data!});

    const keys = Object.keys(reponseRequest[0]);

    keys.forEach((key) => {
      column!.push({ field: key });
    })


    agGrid.api.setColumnDefs(column!);
    agGrid.api.setRowData(reponseRequest);

    request.hourOfStart = new Date();
    request.columns=column!;
    request.row=reponseRequest;

  }

  async reloadRequest(request:Request,agGrid: AgGridAngular,r:any){
    var column = agGrid.api.getColumnDefs();
    column!.length=0
    var reponseRequest! : String[];
console.log(request.hourOfStart)
this.http.get<string[]>(this.requestAPIUrl+'/startRequest/'+request.id).subscribe(data=>{
  reponseRequest=data!
  const keys = Object.keys(reponseRequest[0]);
  
  keys.forEach((key) => {
    column!.push({ field: key });
  })
  
  request.hourOfStart = new Date();
  request.columns=column!;
  request.row=reponseRequest;
  console.log(request.hourOfStart)
  
});


  }


  async createRecrest(requestValue:String): Promise<string[]>{

    var reponseRequest! : string[];

    await this.http.post<string[]>(this.requestAPIUrl+'/createRequest',requestValue).toPromise().then(data=>{reponseRequest=data!});

    return reponseRequest;

  }

  async modifyRequest(requestValue:String, id:number): Promise<string[]>{

    var reponseRequest! : string[];

    await this.http.post<string[]>(this.requestAPIUrl+'/modifyRequest/'+id,requestValue).toPromise().then(data=>{reponseRequest=data!});

    return reponseRequest;

  }

  async verifAllRequestCondition(compte:string){

    var reponseRequest! :Request[];

    await this.http.get<Request[]>(this.requestAPIUrl+'/testConditions/'+compte).toPromise().then(data=>{reponseRequest=data!});

    return reponseRequest;

  }
  
}
