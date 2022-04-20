import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from '../Models/Account';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-identification',
  templateUrl: './identification.component.html',
  styleUrls: ['./identification.component.scss']
})
export class IdentificationComponent implements OnInit {

  Errormessage!:String 
  static loginMake: boolean

  constructor(private service: UserServiceService,private router : Router) { }

  ngOnInit(): void {
  }



  async login(form:NgForm){
    IdentificationComponent.loginMake = await this.service.login(form.value)
    if(IdentificationComponent.loginMake== false)
    this.Errormessage="La combinaise compte mot de passe d'éxiste pas"
   else{
    var account : Account = JSON.parse(JSON.stringify(form.value))
    this.router.navigate(['/menu',account.compte]);
   }
    form.reset()
  }
}
