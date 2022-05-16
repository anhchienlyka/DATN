import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Product } from '../model/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }

  getAllProducts():Observable<HttpResponse<Product[]>>{
    var options = {
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      }),
      responseType:'text' as const
    };
    return this.httpClient.get<Product[]>(this.apiUrl+'Product/GetAllProduct',{observe: 'response' });
  }

getIdProductMax()
{
  var url = this.apiUrl + `Product/GetIdPorductMax`;
    return this.httpClient.get(url, {observe: 'response'});
}
  findProductsByName(name: string){
    var url = this.apiUrl + `Product/GetProductByName?name=${name}`;
    return this.httpClient.get<Product[]>(url, {observe: 'response'});
  }

  findProductsByCategoryId(id: any){
    var url = this.apiUrl + `Product/GetProductByCategoryId?id=${id}`;
    return this.httpClient.get<Product[]>(url, {observe: 'response'});
  }

  findProductsById(id: any){
    var url = this.apiUrl + `Product/GetProductById?id=${id}`;
    return this.httpClient.get<Product[]>(url, {observe: 'response'});
  }

  getFeaturedProducts():Observable<HttpResponse<Product[]>>{
    var options = {
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      }),
      responseType:'text' as const
    };
    return this.httpClient.get<Product[]>(this.apiUrl+'Product/GetFeaturedProduct',{observe: 'response' });
  }
  GetRecentProduct():Observable<HttpResponse<Product[]>>{
    var options = {
      headers: new HttpHeaders({
        'Content-Type':'application/json'
      }),
      responseType:'text' as const
    };
    return this.httpClient.get<Product[]>(this.apiUrl+'Product/GetRecentProduct',{observe: 'response' });
  }

}
