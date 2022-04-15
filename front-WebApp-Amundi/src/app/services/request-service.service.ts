import { APP_ID, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Request } from '../Models/request';
import { ColDef } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';

@Injectable({
  providedIn: 'root'
})
export class RequestServiceService {
  readonly requestAPIUrl="https://localhost:7185/api/Request";
  

  constructor(private http : HttpClient) {
  }

    async GetDescriptionRequests() :Promise<String[]>{
      var description:String[];
        await this.http.get<String[]>(this.requestAPIUrl+'/GetAllRequests').toPromise().then((data)=>description=data!);
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

  async reloadRequest(request:Request,agGrid: AgGridAngular){
    var column = agGrid.api.getColumnDefs();
    column!.length=0
    var reponseRequest! : String[];
   await this.http.get<string[]>(this.requestAPIUrl+'/startRequest/'+request.id).toPromise().then(data=>{reponseRequest=data!});
   const keys = Object.keys(reponseRequest[0]);
 
     keys.forEach((key) => {
    column!.push({ field: key });
   })

   request.hourOfStart = new Date();
   request.columns=column!;
   request.row=reponseRequest;
  }


  createRecrest(requestValue:String){

  }
}
