import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ProductOrder } from 'src/app/model/cart.model';
import { Product } from 'src/app/model/product.model';
import { NotificationService } from 'src/app/notification/notification.service';
import { CartService } from 'src/app/Services/cart.service';
import { Cart } from '../cart/cart.component';

@Component({
  selector: 'app-product-in-home',
  templateUrl: './product-in-home.component.html',
  styleUrls: ['./product-in-home.component.css']
})
export class ProductInHomeComponent implements OnInit {

  coutProduct:number=0;
  sanitizer: DomSanitizer;
  productId: any;
  newPrice: number = 0;
  oldPrice: number = 0;
  relatedProduct: any;
  categoryId?: any;
  quantity: number = 1;
  constructor(
    domSanitizer: DomSanitizer,
    private notifyService : NotificationService,
    private cartService: CartService
    ) {

      this.sanitizer = domSanitizer;
     }

    
  @Input() product!: Product
  ngOnInit(): void {
    this.oldPrice= this.product.price;
    this.newPrice = (this.oldPrice * (100 - this.product.sale)) / 100;
  }
  showToasterWarning(){
    this.notifyService.showWarning("Số lượng hàng không đủ", "Thông báo")
}


addToCart(product: Product) {
  this.coutProduct++;

  if (
    this.quantity > this.product.inventory ||
    this.coutProduct > this.product.inventory
  ) {
    console.log('Số lượng trong kho không đủ!');
    this.notifyService.showError('Số lượng sản phẩm không đủ', 'Thông báo');
    return;
  }
  let productOrder: ProductOrder = {
    price: product.price,
    productId: product.id,
    productName: product.name,
    quantity: this.quantity,
    sale: product.sale,
  };
  this.cartService.addToCart(productOrder);
  this.notifyService.showSuccess('Thêm sản phẩm thành công', 'Thông báo');
  Cart.callBack.emit();
}

}
