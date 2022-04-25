import { Component, OnInit,ViewChild,ViewEncapsulation } from '@angular/core';
import { Request } from '../Models/request';
import { RequestServiceService } from '../services/request-service.service';
import { AgGridAngular } from 'ag-grid-angular';
import { MatDialog,MatDialogConfig } from '@angular/material/dialog';
import { AddRequestComponent } from '../add-request/add-request.component';
import { ModifyRequestComponent } from '../modify-request/modify-request.component';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class MenuComponent implements OnInit {
 
  @ViewChild('agGrid',{static:false}) agGrid! : AgGridAngular

  static availableRequests :Request[]=[];
  columnDefs : any;
  rowData:any;
  requestsStarted : Request[]=[];
  indexRequestShow!: number;
  accountUse!:string  
  testCondiontionMade:boolean=false;
  dateLastTestCondition!:Date;

  constructor(public service: RequestServiceService,private dialog: MatDialog,private route: ActivatedRoute,private router : Router) { }

    async ngOnInit() {

      this.route.params.subscribe((params: Params)=>this.accountUse=params['account']);
      var descriptions = await this.service.GetDescriptionRequests(this.accountUse);

      for(var i =0;i<descriptions.length;i++)
        MenuComponent.availableRequests [i] = descriptions[i];
        console.log(i)

      
   }

    getAvailableRequests(){

      return MenuComponent.availableRequests

    }

   async refreshDescriptionRequests(){

    var descriptions = await this.service.GetDescriptionRequests(this.accountUse);
    this.testCondiontionMade=false;
    for(var i =0;i<descriptions.length;i++){
      MenuComponent.availableRequests[i] = descriptions[i];
    }

   }

   async startRequest(request:Request){

      this.indexRequestShow=0
      this.requestsStarted = [request,...this.requestsStarted];
      this.service.StartedRequest(request,this.agGrid);

    }

    async showRequest (indexRequest:number){

      this.indexRequestShow=indexRequest;
      this.columnDefs=this.requestsStarted[this.indexRequestShow].columns;
      this.rowData=this.requestsStarted[this.indexRequestShow].row;

    }

    async deleteElement(numElement:number){

      this.requestsStarted.splice(numElement, 1);  

        //Changement de la requete afficher  
      if(this.requestsStarted.length==1)
       this.indexRequestShow=0;

      //Si le tableau n'est pas vide
      //On affiche la nouvel requete afficher
      if(this.requestsStarted.length!=0)
       this.showRequest(this.indexRequestShow);
      
      //Si il n'y a plus de requete lancé
      if(this.requestsStarted.length==0)
        this.emptyAgGrid()
      
    }

    isShow(indexRequest: number):boolean{

      return indexRequest == this.indexRequestShow;

    }

    emptyAgGrid(){

      var column = this.agGrid.api.getColumnDefs();
      column!.length=0
      this.agGrid.api.setColumnDefs(column!);
      this.agGrid.api.setRowData(['']);

    }
 
    realoadRequest(request:Request){

      this.service.reloadRequest(request,this.agGrid);

    }


    popupAddRequest(){

     const dialogConfig = new MatDialogConfig();
     dialogConfig.autoFocus=true;
     dialogConfig.width="50%";
     dialogConfig.height="50%";


     //this.dialog.open(AddRequestComponent,dialogConfig)
     this.dialog.open(AddRequestComponent,dialogConfig);
     this.dialog.afterAllClosed.subscribe(result =>  this.refreshDescriptionRequests());

    }

    popupModifyRequest(){

     const dialogConfig = new MatDialogConfig();
     dialogConfig.autoFocus=true;
     dialogConfig.width="50%";
     dialogConfig.height="50%";

    this.dialog.open(ModifyRequestComponent,dialogConfig);
    this.dialog.afterAllClosed.subscribe(result =>  this.refreshDescriptionRequests());

 }

    deconnexion(){

      this.accountUse=''
      this.router.navigate(['/login']);
      
    }

    async verifAllRequestCondition(){

      MenuComponent.availableRequests = await this.service.verifAllRequestCondition(this.accountUse);     
      console.log(MenuComponent.availableRequests)
      this.testCondiontionMade=true;
      this.dateLastTestCondition= new Date();

 }

}

// regler navbar menu 
// faire truc qui tourne lors du test
//reparer ajout et modif !!!!!!!!!!!!!!!!!!!!!!!!!!
// taille navbar !!! couleur
