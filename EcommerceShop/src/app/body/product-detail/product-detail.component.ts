import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductOrder } from 'src/app/model/cart.model';
import { Product } from 'src/app/model/product.model';
import { NotificationService } from 'src/app/notification/notification.service';
import { CartService } from 'src/app/Services/cart.service';
import { ProductService } from 'src/app/Services/product.service';
import { Cart } from '../cart/cart.component';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  product!: Product;
  productId: any;
  coutProduct: number = 0;
  newPrice: number = 0;
  oldPrice: number = 0;
  relatedProduct: any;
  categoryId?: any;
  quantity: number = 1;
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private notifyService: NotificationService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.productId = this.route.snapshot.paramMap.get('id');
    this.getProductById(this.productId);
  }
  getProductById(id: number) {
    let productData: any;
    this.productService.findProductsById(id).subscribe((res) => {
      productData = res.body;
      this.product = productData.data;
      this.oldPrice = this.product.price;
      this.newPrice = (this.oldPrice * (100 - this.product.sale)) / 100;
      this.categoryId = this.product.categoryId;
      this.getProductByCategoryId(this.product.categoryId);
    });
  }

  getProductByCategoryId(id: number) {
    let productData: any;
    this.productService.findProductsByCategoryId(id).subscribe((res) => {
      productData = res.body;
      this.relatedProduct = productData.data;
    });
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

  clickMinus() {
    if (this.quantity >= 0) {
      this.quantity--;
    }
  }
  clickPlus() {
    this.quantity++;
  }
}
