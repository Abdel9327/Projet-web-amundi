import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RequestServiceService } from '../services/request-service.service';

@Component({
  selector: 'app-add-request',
  templateUrl: './add-request.component.html',
  styleUrls: ['./add-request.component.scss']
})
export class AddRequestComponent implements OnInit {

    typeRequest:string="Requete sql"
    ErrorMessages : string[]=[];
  constructor(public service: RequestServiceService) { }

  ngOnInit(): void {
  }


  async addRequest(form : NgForm){
    this.ErrorMessages = ["Test de votre requete en cour"];
  console.log(form.value)
  this.ErrorMessages =  await this.service.createRecrest(form.value)
  }

  onItemChange(type:string){
    this.typeRequest=type;
  }
}
