import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductOrder } from 'src/app/model/cart.model';
import { Order } from 'src/app/model/order.model';
import { OrderDetail } from 'src/app/model/orderDetail.model';
import { User } from 'src/app/model/user.model';
import { NotificationService } from 'src/app/notification/notification.service';
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
  paymentType: number;
  orderDetailsInOrder: OrderDetail[] = [];
  constructor(private cartService: CartService, private checkoutService: CheckoutService, private accountService: AccountService, private route: Router, private notification: NotificationService) { }



  ngOnInit(): void {
    this.getCurrentUser();
    this.productsInCart = this.cartService.getProductInCart();
    this.checkoutAccount();
    this.transfer();

  }

  checkOut1() {
    let newDate = new Date();
    var order: Order = {
      userId: this.currentUser.id,
      orderDate: newDate.toISOString(),
      orderDetails: this.orderDetailsInOrder,
      totalPrice: this.totalCost,
      transacStatus: 1,
      paymentId: this.paymentType,
      toltalCost: this.totalCost
    };
    this.checkoutService.addOrder(order).subscribe();
    let data: string = JSON.stringify(order);
    window.localStorage.removeItem('wallme-cart');
    window.localStorage.removeItem('priceincart');
    Cart.callBack.emit();
    this.route.navigateByUrl('/completed');
  }

  checkOut2() {
    let newDate = new Date();
    var order: Order = {
      userId: this.currentUser.id,
      orderDate: newDate.toISOString(),
      orderDetails: this.orderDetailsInOrder,
      totalPrice: this.totalCost,
      transacStatus: 1,
      paymentId: this.paymentType,
      fullName: this.fullName1.value,
      email: this.email1.value,
      phone: this.phone1.value,
      address: this.address1.value,
      toltalCost: this.totalCost
    };
    this.checkoutService.addOrder(order).subscribe();
    let data: string = JSON.stringify(order);
    window.localStorage.removeItem('wallme-cart');
    window.localStorage.removeItem('priceincart');
    Cart.callBack.emit();
    this.route.navigateByUrl('/completed');
  }


  get total_price(): number {

    return this.cartService.getPriceInCart();
  }
  get totalCost(): number {
    let pricess: number = this.cartService.getPriceInCart();
    if (this.currentUser.customerRank == 2) {
      return pricess - (pricess * 3) / 100;
    }
    if (this.currentUser.customerRank == 3) {
      return pricess - (pricess * 5) / 100;
    }
    if (this.currentUser.customerRank == 4) {
      return pricess - (pricess * 7) / 100;
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

  currentUserForm2 = new FormGroup({
    fullName1: new FormControl(''),
    address1: new FormControl(''),
    phone1: new FormControl(''),
    email1: new FormControl(''),
  });
  checkoutAccount() {
    this.currentUserForm.controls['fullName'].setValue(this.currentUser.fullName);
    this.currentUserForm.controls['userName'].setValue(this.currentUser.userName);
    this.currentUserForm.controls['address'].setValue(this.currentUser.address);
    this.currentUserForm.controls['phone'].setValue(this.currentUser.phone);
    this.currentUserForm.controls['email'].setValue(this.currentUser.email);
  }


  getCurrentUser() {
    this.currentUser = this.accountService.getCurrentUser();
    if (this.currentUser.customerRank == 1) {
      this.customerRank = "Chưa xếp hạng";
      this.dissCount = 0;
    }
    if (this.currentUser.customerRank == 2) {
      this.customerRank = "Hạng Đồng";
      this.dissCount = 3;
    }
    if (this.currentUser.customerRank == 3) {
      this.customerRank = "Hang Bạc";
      this.dissCount = 5;
    }
    if (this.currentUser.customerRank == 4) {
      this.customerRank = "Hạng Vàng";
      this.dissCount = 7;
    }

  }
  transfer() {
    for (let i = 0; i < this.productsInCart.length; i++) {
      let object1: OrderDetail = {
        orderId: 0,
        productId: 0,
        price: 0,
        total_Price: 0,
        quantity: 0
      }
      object1.productId = this.productsInCart[i].productId;
      object1.price = this.productsInCart[i].price;
      object1.total_Price = this.totalCost;
      object1.quantity = this.productsInCart[i].quantity;
      this.orderDetailsInOrder.push(object1)
    }
  }




  get fullName1() {
    return this.currentUserForm2.get('fullName1');
  }
  get userName1() {
    return this.currentUserForm2.get('userName1');
  }
  get address1() {
    return this.currentUserForm2.get('address1');
  }

  get phone1() {
    return this.currentUserForm2.get('phone1');
  }

  get email1() {
    return this.currentUserForm2.get('email1');
  }

  onSubmit() {
    var element1 = <HTMLInputElement>document.getElementById("payment-2");
    var element2 = <HTMLInputElement>document.getElementById("payment-1");
    if (element1.checked == false && element2.checked == false) {
      this.notification.showWarning("Vui lòng chọn phương thức thanh toán", "Thông báo");
      return;
    }

    var element = <HTMLInputElement>document.getElementById("shipto");
    var text = document.getElementById("mytext");
    if (element.checked == true) {
      this.checkOut2();

    } else {
      this.checkOut1();
    }
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
      this.paymentType = 3;
    }
  }
  myFunction3() {
    var element = <HTMLInputElement>document.getElementById("payment-1");
    var text = document.getElementById("payment-2-show");

    if (element.checked == true) {
      text.style.display = "none";
      this.paymentType = 1;
    }
  }


}
