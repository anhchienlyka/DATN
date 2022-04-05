import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor() {}
  public editCart:any={cart:0,products:[]};
  public subject = new Subject<any>();
  private cartSource = new BehaviorSubject(this.editCart);
  public  currentCart = this.cartSource.asObservable();
  updateCart(item:any)
  {
    this.cartSource.next(item)
  }
}
