import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  apiUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }
  login(formData: any){
    var options = {
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      }),
      responseType:'text' as const
    };
    return this.httpClient.post(this.apiUrl+'Account/Login', formData,options);
  }
}


