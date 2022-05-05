import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductOrder } from 'src/app/model/cart.model';
import { Order } from 'src/app/model/order.model';
import { OrderDetail } from 'src/app/model/orderDetail.model';
import { User } from 'src/app/model/user.model';
import { AccountService } from 'src/app/Services/account.service';
import { CartService } from 'src/app/Services/cart.service';
import { CheckoutService } from 'src/app/Services/checkout.service';
import { Cart } from '../cart/cart.component';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  currentUser?: User;
  productsInCart: ProductOrder[];
  quantity?: any;
  dissCount: number = 0;
  customerRank: string;
  paymentType:number;
  orderDetailsInOrder: OrderDetail[] = [];
  constructor(private cartService: CartService, private checkoutService: CheckoutService,private accountService : AccountService, private route : Router) { }
  


  ngOnInit(): void {
    this.getCurrentUser();
    this.productsInCart = this.cartService.getProductInCart();
    this.checkoutAccount();
    this.transfer();
    
  }

  onSubmit(){
    let newDate = new Date();
    var order: Order ={
      
      userId: this.currentUser.id,
      orderDate: newDate.toISOString(),
      orderDetails: this.orderDetailsInOrder,
      totalPrice: this.totalCost,
      transacStatus: 1,
      paymentId: this.paymentType,
      user:this.currentUser
    };
    this.checkoutService.addOrder(order).subscribe();
    let data: string = JSON.stringify(order);
    window.localStorage.removeItem('wallme-cart');
    window.localStorage.removeItem('priceincart');
    Cart.callBack.emit();
    this.route.navigateByUrl('/completed');
  }

  get total_price() :number{

    return  this.cartService.getPriceInCart();
  }
  get totalCost() : number
  {
    let pricess : number= this.cartService.getPriceInCart();
    if(this.currentUser.customerRank==2){
      return pricess - (pricess*3)/100;
    }
    if(this.currentUser.customerRank==3){
      return pricess - (pricess*5)/100;
    }
    if(this.currentUser.customerRank==4){
      return pricess - (pricess*7)/100;
    }
    return pricess;
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
    if(this.currentUser.customerRank==1){
      this.customerRank = "Chưa xếp hạng";
      this.dissCount =0;
    }
    if(this.currentUser.customerRank==2){
      this.customerRank = "Hạng Đồng";
        this.dissCount =3;
    }
    if(this.currentUser.customerRank==3){
      this.customerRank = "Hang Bạc";
      this.dissCount =5;
    }
    if(this.currentUser.customerRank==4){
      this.customerRank = "Hạng Vàng";
      this.dissCount =7;
    }

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
      object1.total_Price =this.totalCost;
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
      this.paymentType=3;
    }
  }
  myFunction3() {
    var element = <HTMLInputElement>document.getElementById("payment-1");
    var text = document.getElementById("payment-2-show");

    if (element.checked == true) {
      text.style.display = "none";
     this.paymentType=1;
    }
  }


}
