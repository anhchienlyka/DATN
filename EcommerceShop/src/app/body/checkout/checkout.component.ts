import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProductOrder } from 'src/app/model/cart.model';
import { OrderDetail } from 'src/app/model/orderDetail.model';
import { User } from 'src/app/model/user.model';
import { AccountService } from 'src/app/Services/account.service';
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
  total_price?: number;
  totalCost?: number;
  orderDetailsInOrder: OrderDetail[] = [];
  constructor(private cartService: CartService, private checkoutService: CheckoutService,private accountService : AccountService) { }
  //constructor(private authenticationService: AuthenticationService,private cartService: CartService, private orderService:OrderService) {}



  ngOnInit(): void {
    this.getCurrentUser();
    this.checkoutAccount();
  }

  onSubmit() {

  }

  currentUserForm = new FormGroup({
    fullName: new FormControl(''),
    userName: new FormControl(''),
    address: new FormControl(''),
    phone: new FormControl(''),
    email: new FormControl(''),
  });
  checkoutAccount
    () {
    this.currentUserForm.controls['fullName'].setValue(this.currentUser.fullName);
    this.currentUserForm.controls['userName'].setValue(this.currentUser.userName);
    this.currentUserForm.controls['address'].setValue(this.currentUser.address);
    this.currentUserForm.controls['phone'].setValue(this.currentUser.phone);
    this.currentUserForm.controls['email'].setValue(this.currentUser.email);

  }


  getCurrentUser() {
    this.currentUser = this.accountService.getCurrentUser();
  }
  transfer(){
    for(let i = 0 ; i< this.productsInCart.length; i++ ){
      let object1:OrderDetail = {
        orderId: 0,
        productId: 0,
        price: 0,
        total_Price: 0,
        quantity:0
      }
      object1.productId = this.productsInCart[i].productId;
      object1.price = this.productsInCart[i].price;
    //  object1.total_Price =this.totalPrice;
      object1.quantity= this.productsInCart[i].quantity;
      this.orderDetailsInOrder.push(object1)
    }

    // console.log(this.orderDetailsInOrder)
  }













  myFunction() {
    var element = <HTMLInputElement>document.getElementById("shipto");
    var text = document.getElementById("mytext");
    if (element.checked == true) {
      text.style.display = "block";
    } else {
      text.style.display = "none";
    }
  }


  myFunction2() {
    var element = <HTMLInputElement>document.getElementById("payment-2");
    var text = document.getElementById("payment-2-show");

    if (element.checked == true) {
      text.style.display = "block";
    }
  }
  myFunction3() {
    var element = <HTMLInputElement>document.getElementById("payment-1");
    var text = document.getElementById("payment-2-show");

    if (element.checked == true) {
      text.style.display = "none";
      text.style.display = "none";
    }
  }


}
