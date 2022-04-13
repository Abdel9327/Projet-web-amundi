import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RequestServiceService {
  readonly requestAPIUrl="https://localhost:7185/api/Request";
  descriptionsRequests$:String[]=[];
  reponseRequest$!:Object[];
  t$:String[]=[];
  stringRow!:string

  constructor(private http : HttpClient) {
  }

  GetDescriptionRequests(){
    this.http.get<String[]>(this.requestAPIUrl+'/GetAllRequests').subscribe(data=>{this.descriptionsRequests$=data});
  }

 StartedRequest(){
  this.stringRow='['
     this.http.get<Object[]>(this.requestAPIUrl+'/startRequest/0').subscribe(data=>{this.reponseRequest$=data});

     
    for(var i =0; i<Object.keys(this.reponseRequest$).length;i++){
      if(i==Object.keys(this.reponseRequest$).length-1)
      this.stringRow=this.stringRow+"{\"headerName\":\"" + Object.keys(this.reponseRequest$[0])[i] +"\","+ "\"field\":\""+Object.keys(this.reponseRequest$[0])[i]+"\"}";
      else
      this.stringRow=this.stringRow+"{\"headerName\":\"" + Object.keys(this.reponseRequest$[0])[i] +"\","+ "\"field\":\""+Object.keys(this.reponseRequest$[0])[i]+"\"},";
     }

     console.log(Object.keys(this.reponseRequest$[0]))
    this.stringRow=this.stringRow + ']'
   
     this.stringRow=  JSON. parse(this.stringRow)
  

  }

  
  
  columnDefs() {
    
  
}

}
