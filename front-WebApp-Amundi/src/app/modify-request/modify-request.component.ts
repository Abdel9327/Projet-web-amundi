import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MenuComponent } from '../menu/menu.component';
import { Request } from '../Models/request';


@Component({
  selector: 'app-modify-request',
  templateUrl: './modify-request.component.html',
  styleUrls: ['./modify-request.component.scss']
})
export class ModifyRequestComponent implements OnInit {
  typeRequest:string="Requete sql"
  formShow: boolean = false
    requeteShowToModify! : Request
  constructor() { }

  ngOnInit(): void {
  }


  getAvailableRequests(){
    return MenuComponent.availableRequests
  }

  modifyRequest(form : NgForm){

  }

  showFormodifyRequest(request:Request){
    this.requeteShowToModify = request;
    this.formShow = true ;
  }

  onItemChange(type:string){
    this.typeRequest=type;
  }

  
}
