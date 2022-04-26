import { EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ProductOrder } from 'src/app/model/cart.model';
import { Product } from 'src/app/model/product.model';
import { NotificationService } from 'src/app/notification/notification.service';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from 'src/app/Services/product.service';

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
  ngOnInit(): void {
    this.productsInCart = this.cartService.getProductInCart();
  }

  constructor(
    private cartService: CartService,
    private route: Router,
    sanitizer: DomSanitizer,
    private notificationSevice: NotificationService,
    private productService: ProductService
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
    this.maKhuyenMai = capoun.value;
    console.log('makhuyen mai', this.maKhuyenMai);
  }
  huyKhuyenMai()
  {
    this.maKhuyenMai='';
  }

}

export class Cart {
  static callBack = new EventEmitter();
}
