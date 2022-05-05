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
  stringRowAddOrDelete:string=''
  nbRowModify:number=0
  stringRowModify:string=''
  listRowModify: String[]=[]

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

  if( this.request1.row.length != this.request2.row.length){
   this.nbRowAddOrDelete = this.request1.row.length - this.request2.row.length;
    if( this.nbRowAddOrDelete<0)
      this.stringRowAddOrDelete=  Math.abs(this.nbRowAddOrDelete) + " lignes ont été supprimés:";
      else
      this.stringRowAddOrDelete=   this.nbRowAddOrDelete + " lignes ont été ajoutés:";


  }

  //probleme il faut boucler sur les data ou il y a le moin de ligne ! si nn prlm
  for(var i = 0; i<this.request1.row.length;i++){
    //Comparaison si des modifs on été effectué sur la meme row
    //Si la clef primaire est la meme alors on peut comparer
    
    console.log(Object.values(this.request1.row[i])[0]  == Object.values(this.request2.row[i])[0])
   if(Object.values(this.request1.row[i])[0]  == Object.values(this.request2.row[i])[0]){

     if(!_.isEqual(this.request1.row[i],this.request2.row[i])){    console.log("ok2")

      this.nbRowModify++;
      console.log("Clef Primaire : " + Object.values(this.request1.row[i])[0]   + "\nAvant modification : " + JSON.stringify(this.request1.row[i])  + "\nAprès modification : " +  JSON.stringify(this.request2.row[i]))
       this.listRowModify = [  ...this.listRowModify , "Clef Primaire : " + Object.values(this.request1.row[i])[0]   + "\n Avant modification : " + JSON.stringify(this.request1.row[i])  + " Après modification : " +  JSON.stringify(this.request2.row[i]) ];
     }
   }
  }
  
}
  
}
