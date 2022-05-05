import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Order, OrderVms } from '../model/order.model';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private apiUrl = environment.apiUrl;
  constructor(private httpClient : HttpClient) { 

  }

  getOrders():Observable<HttpResponse<OrderVms[]>>{
    return this.httpClient.get<OrderVms[]>(this.apiUrl+'order',{observe: 'response'});
  }


  addOrder(order: Order){
    var data = JSON.stringify(order);
    var url = this.apiUrl+'Order/AddOrder';
    var options = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json'
          })
        };
    return this.httpClient.post<any>(url, data, options);
  }

}
