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
  productsInCart?: ProductOrder[];
  values: any;
  maKhuyenMai: string = '';
  sanitizer: DomSanitizer;
  productDetail?: Product;
  salecodeName: Salecode;
  valueSale: number = 0;
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
  get totalPrice(): number {
    let totalPrices= this.productsInCart?.reduce(
      (acc, cur) => acc + (cur.price * cur.quantity * (100 - cur.sale)) / 100,
      0
    );
    if(totalPrices>0)return totalPrices;
    return 0;
  }

  get totalCost(): number {
    if (this.valueSale > 0) {
      return this.totalPrice - (this.valueSale * this.totalPrice) / 100 + 30000;
    }
    return this.totalPrice + 30000;
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
          this.maKhuyenMai = this.salecodeName.codeName;
          this.valueSale = this.salecodeName.valueCode;
          this.notificationSevice.showSuccess(
            'Thêm mã khuyến mại thành công',
            'Thông báo'
          );
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
    this.valueSale = 0;
  }

  delete(item: any) {
    this.cartService.removeCartItem(item);
    this.productsInCart = this.cartService.getProductInCart();
    Cart.callBack.emit();
  }

  checkOut() {
    var products = this.cartService.getProductInCart();
    if (products.length > 0) {
      products.forEach((product) => {
        let sanpham: any;
        this.productService
          .findProductsById(product.productId)
          .subscribe((res) => {
            sanpham = res.body;
            this.productDetail = sanpham.data;
            if (product.quantity > this.productDetail.inventory!) {
              this.route.navigateByUrl('/cart');
              this.notificationSevice.showError(
                'Sản phẩm trong giỏ hàng không đủ',
                'Thông báo'
              );
            }
          });
      });
      this.route.navigateByUrl('/cart/checkout');
    } else {
      this.route.navigateByUrl('/cart');
      this.notificationSevice.showWarning('Giỏ hàng rỗng', 'Thông báo');
    }
  }
}

export class Cart {
  static callBack = new EventEmitter();
}
