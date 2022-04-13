import { Component, OnInit } from '@angular/core';
import { RequestServiceService } from '../services/request-service.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
 

  availableRequests :any[]=[];
  constructor(public service: RequestServiceService) { }

  ngOnInit(): void {
    
    console.log(this.service.GetDescriptionRequests());
    this.availableRequests [0]=this.service.GetDescriptionRequests();
  }


    async startRequest(numElement:number){
     this.service.StartedRequest();
     this.service.columnDefs();
     this.rowData=this.service.reponseRequest$;
     this.columnDefs=this.service.stringRow;
    }

    async showElement (numElement:number){
      
    }

    async deleteElement(numElement:number){
  
      
    }

 


    columnDefs : any;
  //data variable
  rowData:any;

    
  


}


// taille navbar
// le nombre de requete dans json modifier et rendre automatique