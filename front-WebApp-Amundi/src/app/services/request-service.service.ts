import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Request } from '../Models/request';

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

 async StartedRequest(request:Request){
   var stringColumnAggrid :string;
   var reponseRequest : String[] = [];
   stringColumnAggrid='['

    await this.http.get<string[]>(this.requestAPIUrl+'/startRequest/'+request.id).toPromise().then(data=>{reponseRequest=data!});

   console.log(Object.keys(reponseRequest[0]).length)
   console.log(Object.keys(reponseRequest[0]))

   var i ;
    for( i =0; i<Object.keys(reponseRequest[0]).length;i++){
      if(i==Object.keys(reponseRequest[0]).length-1)
      stringColumnAggrid=stringColumnAggrid+"{\"headerName\":\"" + Object.keys(stringColumnAggrid[0])[i] +"\","+ "\"field\":\""+Object.keys(reponseRequest[0])[i]+"\"}";
      else
      stringColumnAggrid=stringColumnAggrid+"{\"headerName\":\"" + Object.keys(reponseRequest[0])[i] +"\","+ "\"field\":\""+Object.keys(reponseRequest[0])[i]+"\"},";
      console.log("ddd" + Object.keys(stringColumnAggrid[0])[i])
     }
     console.log(i)
     stringColumnAggrid = stringColumnAggrid + ']'
     stringColumnAggrid =  JSON.parse(stringColumnAggrid)
     console.log( stringColumnAggrid)
     console.log(Object.keys(reponseRequest[0])[7])


     return [stringColumnAggrid, reponseRequest];

  }

  
  
  

}
