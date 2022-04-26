import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MenuComponent } from '../menu/menu.component';
import { Request } from '../Models/request';
import { RequestServiceService } from '../services/request-service.service';


@Component({
  selector: 'app-modify-request',
  templateUrl: './modify-request.component.html',
  styleUrls: ['./modify-request.component.scss']
})
export class ModifyRequestComponent implements OnInit {
    typeRequest:string="Requete sql"
    requeteShowToModify! : Request
    ErrorMessages : string[]=[];

  constructor(public service: RequestServiceService) { }

  ngOnInit(): void {
  }


  getAvailableRequests(){
    return MenuComponent.availableRequests
  }

  async modifyRequest(form : NgForm){
    this.ErrorMessages = ["Test de votre requete en cours"];
    this.ErrorMessages= await this.service.modifyRequest(form.value, this.requeteShowToModify.id)
  }

  showFormodifyRequest(request:Request){
    this.requeteShowToModify = request;
  }

  onItemChange(type:string){
    this.typeRequest=type;
  }
  
}
