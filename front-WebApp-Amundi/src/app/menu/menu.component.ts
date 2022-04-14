import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { Request } from '../Models/request';
import { RequestServiceService } from '../services/request-service.service';
import * as _ from 'lodash';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  encapsulation: ViewEncapsulation.None,

})
export class MenuComponent implements OnInit {
 

  availableRequests :Request[]=[];
  columnDefs : any;
  rowData:any;
  requestsStarted : Request[]=[];
  requestShow!: Request;
    

  constructor(public service: RequestServiceService) { }

    async ngOnInit() {
     
      var descriptions = await this.service.GetDescriptionRequests();

      for(var i =0;i<descriptions.length;i++){
        this.availableRequests [i] = new Request(i,descriptions[i]);
      }
   }


   async startRequest(request:Request){
      request.hourOfStart = new Date();
      this.requestShow=request
      this.requestsStarted = [request,...this.requestsStarted];
      var response = await this.service.StartedRequest(request);
      //ajouter columnsdef et row
      request.columns=response[0];
      request.row=response[1];
      this.columnDefs= request.columns;
      this.rowData=request.row;

    }

    async showRequest (request:Request){
      this.requestShow=request;
      this.columnDefs=this.requestShow.columns;
      this.rowData=this.requestShow.row;
    }

    async deleteElement(numElement:number){
      console.log(this.requestsStarted.length)
      this.requestsStarted.splice(numElement, 1);      
    }

 isEqual(request:Request):boolean{
   // Defining Lodash variable 
  return _.isEqual(request,this.requestShow);
 }


}

//faire reload et delete
//recuperer index tab afficher
// taille navbar
// le nombre de requete dans json modifier et rendre automatique
// possibilité de mettre en pleine ecran aggrid
//reparer derniere case aggrid !!