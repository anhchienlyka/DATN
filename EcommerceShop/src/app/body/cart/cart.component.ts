import { EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ProductOrder } from 'src/app/model/cart.model';
import { Product } from 'src/app/model/product.model';
import { Salecode } from 'src/app/model/salecode';
import { NotificationService } from 'src/app/notification/notification.service';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from 'src/app/Services/product.service';
import { SalecodeService } from 'src/app/Services/salecode.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  productsInCart: ProductOrder[];
  values: any;
  maKhuyenMai: string = '';
  sanitizer: DomSanitizer;
  productDetail: Product;
  salecodeName: Salecode;
  ngOnInit(): void {
    this.productsInCart = this.cartService.getProductInCart();
  }

  constructor(
    private cartService: CartService,
    private route: Router,
    sanitizer: DomSanitizer,
    private notificationSevice: NotificationService,
    private productService: ProductService,
    private salecodeService: SalecodeService
  ) {
    this.sanitizer = sanitizer;
  }

  clickMinus(quantity: number = 1) {
    if (quantity >= 0) {
      quantity--;
      this.values = quantity;
    }
  }
  clickPlus(quantity: number = 1) {
    quantity++;
    this.values = quantity;
  }

  addKhuyenMai(capoun: any) {
    let maKm: any;
    let dateTime = new Date();
    this.salecodeService
      .getSaleCodeByCodeName(capoun.value)
      .subscribe((res) => {
        console.log('ressss', res.body);
        maKm = res.body;
        this.salecodeName = maKm.data;
        if (this.salecodeName != null) {
          if (
            formatDate(this.salecodeName.startDateCode) <=
              formatDate(dateTime) &&
            formatDate(this.salecodeName.endDateCode) >= formatDate(dateTime)
          ) {
            this.maKhuyenMai = this.salecodeName.codeName;
          }
        } else {
          this.notificationSevice.showWarning(
            'Mã khuyến mại không tồn tại',
            'Thông báo'
          );
        }
      });
  }
  huyKhuyenMai() {
    this.maKhuyenMai = '';
  }
}

function padTo2Digits(num: number) {
  return num.toString().padStart(2, '0');
}
function formatDate(date: Date) {
  return (
    [
      date.getFullYear(),
      padTo2Digits(date.getMonth() + 1),
      padTo2Digits(date.getDate()),
    ].join('-') +
    ' ' +
    [
      padTo2Digits(date.getHours()),
      padTo2Digits(date.getMinutes()),
      padTo2Digits(date.getSeconds()),
    ].join(':')
  );
}

export class Cart {
  static callBack = new EventEmitter();
}
