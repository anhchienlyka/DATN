import { Component, OnInit } from '@angular/core';
import { Order, OrderVms } from 'src/app/model/order.model';
import { NotificationService } from 'src/app/notification/notification.service';
import { CheckoutService } from 'src/app/Services/checkout.service';

@Component({
  selector: 'app-myaccount',
  templateUrl: './myaccount.component.html',
  styleUrls: ['./myaccount.component.css']
})
export class MyaccountComponent implements OnInit {


  listOrder:OrderVms[]

  constructor(private checkOutService:CheckoutService,private notification:NotificationService) { 


  }

  ngOnInit(): void {
  }



  getListOrderByUserId(){
    
  }
}
