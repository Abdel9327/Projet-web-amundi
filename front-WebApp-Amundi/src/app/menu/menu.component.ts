import { Component, OnInit,ViewChild,ViewEncapsulation } from '@angular/core';
import { Request } from '../Models/request';
import { RequestServiceService } from '../services/request-service.service';
import { AgGridAngular } from 'ag-grid-angular';
import { MatDialog,MatDialogConfig } from '@angular/material/dialog';
import { AddRequestComponent } from '../add-request/add-request.component';
import { ModifyRequestComponent } from '../modify-request/modify-request.component';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { DataCheckerComponent } from '../data-checker/data-checker.component';

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
  DocompRequest:boolean=false;
  DocComp:Request[]=[];

  constructor(public service: RequestServiceService,private dialog: MatDialog,private route: ActivatedRoute,private router : Router) { }

    async ngOnInit() {

      this.route.params.subscribe((params: Params)=>this.accountUse=params['account']);
      var descriptions = await this.service.GetDescriptionRequests(this.accountUse);

      for(var i =0;i<descriptions.length;i++)
        MenuComponent.availableRequests [i] = descriptions[i];

        
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

     startRequest(request:Request){

      this.indexRequestShow=0

      //Pour que les requetes on des différentes références
      const obj = Object.assign({},request)
      this.requestsStarted = [obj,...this.requestsStarted];
      this.service.StartedRequest(obj,this.agGrid);

    }

    showRequest (indexRequest:number){

     
      //Il faut que les requetes sélectionner ont le meme id, mais elles doivent etre des instance de class différente
      if(this.DocompRequest && (this.DocComp.length==0 || this.DocComp[0].id== this.requestsStarted[indexRequest].id) &&  this.DocComp[0]!= this.requestsStarted[indexRequest]){
        this.DocComp=[this.requestsStarted[indexRequest],...this.DocComp];
        if(this.DocComp.length==2){
         
   this.popupDataChecker();

        }
      }

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
 
    realoadRequest(request:number){
      this.service.reloadRequest(this.requestsStarted[request],this.agGrid, this.requestsStarted);

    }


    popupAddRequest(){

     const dialogConfig = new MatDialogConfig();
     dialogConfig.autoFocus=true;
     dialogConfig.width="55%";
     dialogConfig.height="72%";


     //this.dialog.open(AddRequestComponent,dialogConfig)
     this.dialog.open(AddRequestComponent,dialogConfig);
     this.dialog.afterAllClosed.subscribe(result =>  this.refreshDescriptionRequests());

    }

    popupModifyRequest(){

     const dialogConfig = new MatDialogConfig();
     dialogConfig.autoFocus=true;
     dialogConfig.width="52.5%";
     dialogConfig.height="65%";

     this.dialog.open(ModifyRequestComponent,dialogConfig);
     this.dialog.afterAllClosed.subscribe(result =>  this.refreshDescriptionRequests());

 }

 popupDataChecker(){
   

  this.DocompRequest=false;

    this.dialog.open(DataCheckerComponent,
      {autoFocus:true,
        width:"55%",
        height:"80%",
        data:{
        Request1: this.DocComp[0],
        Request2: this.DocComp[1]}
      });
      this.dialog.afterAllClosed.subscribe(result => {
    this.DocComp=[]});
  
      }
 
  

    deconnexion(){

      MenuComponent.availableRequests= [];
      this.accountUse=''
      this.router.navigate(['/login']);
     
    }

    async verifAllRequestCondition(){

      MenuComponent.availableRequests = await this.service.verifAllRequestCondition(this.accountUse);     
      this.testCondiontionMade=true;
      this.dateLastTestCondition= new Date();

 }

 getRequestCond(){
   var requeteCond : Request[] = []
   for(var i = 0; i<MenuComponent.availableRequests.length;i++){
     if(MenuComponent.availableRequests[i].condition != null)
     requeteCond=[...requeteCond,MenuComponent.availableRequests[i]]
   }
     return requeteCond;
 }


 compareRequest(){
  this.DocompRequest= !this.DocompRequest;
  if(!this.DocompRequest)
  this.DocComp=[]
 }

 isCompared(request:number) : boolean{
   for(var i =0;i<this.DocComp.length;i++ ){
    if(this.DocComp[i]==this.requestsStarted[request])
      return true;
   }
   return false;

 }
}


//finir analyse des données
//tester code sans index
//optimiser json


//gestion de la concurence effectuer
//jai supp tous les string + string
// jai separer les requetes cond et requete normal
//amelioratin de la vitesse d'éxecution et de la complexité du code
