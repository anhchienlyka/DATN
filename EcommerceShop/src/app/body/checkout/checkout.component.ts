import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProductOrder } from 'src/app/model/cart.model';
import { OrderDetail } from 'src/app/model/orderDetail.model';
import { User } from 'src/app/model/User.model';
import { CartService } from 'src/app/Services/cart.service';
import { CheckoutService } from 'src/app/Services/checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  currentUser: User;
  productsInCart: ProductOrder[];
  quantity?: any; 
  total_price?:number;
  totalCost?: number;
  orderDetailsInOrder: OrderDetail[] = [];
  constructor(private cartService: CartService,private checkoutService:CheckoutService,private notification:Notification) {}
  //constructor(private authenticationService: AuthenticationService,private cartService: CartService, private orderService:OrderService) {}

  

  ngOnInit(): void {
  }

  onSubmit(){

  }

  currentUserForm = new FormGroup({
    fullname: new FormControl(''),
    username: new FormControl(''),
    address: new FormControl(''),
    phoneNumber: new FormControl(''),
    email: new FormControl(''),
  });

  checkoutAccount() {
    this.currentUserForm.controls['fullname'].setValue(this.currentUser.fullname);
    this.currentUserForm.controls['username'].setValue(this.currentUser.username);
    this.currentUserForm.controls['address'].setValue(this.currentUser.address);
    this.currentUserForm.controls['phoneNumber'].setValue(this.currentUser.phoneNumber);
    this.currentUserForm.controls['email'].setValue(this.currentUser.email);
    
  }
   myFunction() {
    var element = <HTMLInputElement> document.getElementById("shipto");
    var text = document.getElementById("mytext");
    if (element.checked == true){
      text.style.display = "block";
    } else {
      text.style.display = "none";
    }
  }
}
