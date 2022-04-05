import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/model/product.model';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  product!: Product;
  productId: any;
  newPrice: number = 0;
  oldPrice: number = 0;
  relatedProduct: any;
  categoryId? : any
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
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
      this.categoryId= this.product.categoryId
      this.getProductByCategoryId(this.product.categoryId);
    });
  }

  getProductByCategoryId(id:number)
  {
    let productData: any;
    this.productService.findProductsByCategoryId(id).subscribe((res) => {
      productData = res.body;
      this.relatedProduct = productData.data
    })
  }
}
