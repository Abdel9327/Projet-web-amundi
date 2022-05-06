import { Component, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { Request } from '../Models/request';
import { DatePipe } from '@angular/common';
import * as _ from 'lodash';

@Component({
  selector: 'app-data-checker',
  templateUrl: './data-checker.component.html',
  styleUrls: ['./data-checker.component.scss'],
  providers: [DatePipe]

})
export class DataCheckerComponent implements OnInit {

  request1! : Request
  request2! : Request
  analyse! : string
  nbRowAddOrDelete:number=0
  nbRowModify:number=0
  listRowModify: String[]=[]
  listRowDelete: String[]=[]
  listRowAdd: String[]=[]


  constructor(   @Inject(MAT_DIALOG_DATA) public data: any,private datePipe: DatePipe
  ) {  this.request1 = this.data.Request1;
    this.request2 = this.data.Request2;}

  ngOnInit(): void {

   

   
    if( _.isEqual(this.request2.row,this.request1.row)){
      this.analyse= "Aucune modification a était apporté  pour la requete \""+ this.request1.description+ "\" entre " +  this.datePipe.transform( this.request1.hourOfStart, 'MMM d, y, h:mm:ss a')   + " et " +  this.datePipe.transform( this.request2.hourOfStart, 'MMM d, y, h:mm:ss a') +".";
    }
    else {
      this.analyse= "Des modifications ont été apporté pour la requete \""+ this.request1.description+ "\" entre " +   this.datePipe.transform( this.request1.hourOfStart, 'MMM d, y, h:mm:ss a')  + " et " +  this.datePipe.transform( this.request2.hourOfStart, 'MMM d, y, h:mm:ss a') +"." ;
      this.analyseRequests();
   
    }

  }

analyseRequests(){

if(this.request1.row.length<this.request2.row.length){
  for(var i = 0; i<this.request1.row.length;i++){
    //Comparaison si des modifs on été effectué sur la meme row
    //Si la clef primaire est la meme alors on peut comparer
    
   if(Object.values(this.request1.row[i])[0]  == Object.values(this.request2.row[i])[0]){
     if(!_.isEqual(this.request1.row[i],this.request2.row[i])){    
      this.nbRowModify++;
       this.listRowModify = [  ...this.listRowModify , "Clef Primaire : " + Object.values(this.request1.row[i])[0]   + "\nAvant modification : " + JSON.stringify(this.request1.row[i])  + "\nAprès modification : " +  JSON.stringify(this.request2.row[i]) ];
     }
   }
  }
}
else{
  for(var i = 0; i<this.request2.row.length;i++){
    //Comparaison si des modifs on été effectué sur la meme row
    //Si la clef primaire est la meme alors on peut comparer
    
   if(Object.values(this.request2.row[i])[0]  == Object.values(this.request1.row[i])[0]){
     if(!_.isEqual(this.request1.row[i],this.request2.row[i])){    
      this.nbRowModify++;
       this.listRowModify = [  ...this.listRowModify , "Clef Primaire : " + Object.values(this.request2.row[i])[0]   + "\nAvant modification : " + JSON.stringify(this.request1.row[i])  + "\nAprès modification : " +  JSON.stringify(this.request2.row[i]) ];
     }
   }
  }
}

  
    for(var i = 0; i<this.request1.row.length;i++){
      for(var y = 0; y<this.request2.row.length;y++){
        if(Object.values(this.request1.row[i])[0]  == Object.values(this.request2.row[y])[0]){    console.log("ok 2")

          break;
        }
       

        if(y==this.request2.row.length-1){   

          this.listRowDelete=[... this.listRowDelete,"Clef Primaire : " +  Object.values(this.request1.row[i])[0] + "\nLigne supprimé: " +  JSON.stringify(this.request1.row[i])];
        }
    }
  }



  for(var i = 0; i<this.request2.row.length;i++){
    for(var y = 0; y<this.request1.row.length;y++){
      if(Object.values(this.request1.row[y])[0]  == Object.values(this.request2.row[i])[0]){   
        break;
      }
    console.log(y + "et" +( this.request1.row.length-1))
      if(y==this.request1.row.length-1){ 
        console.log("fait")   
        this.listRowAdd=[... this.listRowAdd,"Clef Primaire : " +  Object.values(this.request2.row[i])[0] + "\nLigne ajouté: " +  JSON.stringify(this.request2.row[i])];
        console.log(  this.listRowAdd)
      }
  }

}
}}
