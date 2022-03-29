import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Category } from '../model/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }
//https://localhost:44311/api/Category/GetAllCategory
  getCategories():Observable<HttpResponse<Category[]>>{
    return this.httpClient.get<Category[]>(this.apiUrl+'Category/GetAllCategory',{observe: 'response'});
  }








}
