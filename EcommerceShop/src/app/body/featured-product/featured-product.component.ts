import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-featured-product',
  templateUrl: './featured-product.component.html',
  styleUrls: ['./featured-product.component.css'],
})
export class FeaturedProductComponent implements OnInit {
  constructor(private productService: ProductService) {}
  products: any;
  ngOnInit(): void {
    this.getProduct();
  }

  getProduct() {
    let product: any;
    this.productService.getFeaturedProducts().subscribe((res) => {
      product = res.body;
      this.products = product.data;
      console.log("resproductFeatured",res.body)
    });
  }
}
