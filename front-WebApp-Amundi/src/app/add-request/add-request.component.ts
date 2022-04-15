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
    ErrorMessage! : string;
  constructor(public service: RequestServiceService) { }

  ngOnInit(): void {
  }


  addRequest(form : NgForm){
console.log(form.value)
this.service.createRecrest(form.value)
  }

  onItemChange(type:string){
    this.typeRequest=type;
  }
}
