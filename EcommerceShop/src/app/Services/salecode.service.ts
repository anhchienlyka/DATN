import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Salecode } from '../model/salecode';

@Injectable({
  providedIn: 'root'
})
export class SalecodeService {

  private apiUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }

//https://localhost:44311/api/SaleCode/GetCodeByCodeName?name=d
  getSaleCodeByCodeName (codeName:string){
    var url = this.apiUrl + `SaleCode/GetCodeByCodeName?name=${codeName}`;
    return this.httpClient.get<Salecode[]>(url, {observe: 'response'});
  }
}
