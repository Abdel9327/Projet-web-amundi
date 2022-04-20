import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  readonly requestAPIUrl="https://localhost:7185/api/User";
  constructor(private http : HttpClient) {
  }


  async login(user:String){

      var loginMake! : boolean;
      await this.http.post<boolean>(this.requestAPIUrl+'/login',user).toPromise().then(data=>{loginMake=data!});
      return loginMake ;
    }
  }

