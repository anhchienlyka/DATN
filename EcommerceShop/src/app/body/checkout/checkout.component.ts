import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProductOrder } from 'src/app/model/cart.model';
import { OrderDetail } from 'src/app/model/orderDetail.model';
import { User } from 'src/app/model/user.model';
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
  constructor(private cartService: CartService,private checkoutService:CheckoutService) {}
  //constructor(private authenticationService: AuthenticationService,private cartService: CartService, private orderService:OrderService) {}

  

  ngOnInit(): void {
  }

  onSubmit(){

  }

  currentUserForm = new FormGroup({
    fullName: new FormControl(''),
    userName: new FormControl(''),
    address: new FormControl(''),
    phone: new FormControl(''),
    email: new FormControl(''),
  });

  checkoutAccount() {
    this.currentUserForm.controls['fullName'].setValue(this.currentUser.fullName);
    this.currentUserForm.controls['userName'].setValue(this.currentUser.userName);
    this.currentUserForm.controls['address'].setValue(this.currentUser.address);
    this.currentUserForm.controls['phone'].setValue(this.currentUser.phone);
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


  myFunction2() {
    var element = <HTMLInputElement> document.getElementById("payment-2");
    var text = document.getElementById("payment-2-show");
 
    if (element.checked == true){
      text.style.display = "block";
    }
  }
  myFunction3() {
    var element = <HTMLInputElement> document.getElementById("payment-1");
    var text = document.getElementById("payment-2-show");
 
    if (element.checked == true){
      text.style.display = "none";
   text.style.display = "none";
    }
  }


}
