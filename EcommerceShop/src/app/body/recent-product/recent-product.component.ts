import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-recent-product',
  templateUrl: './recent-product.component.html',
  styleUrls: ['./recent-product.component.css']
})
export class RecentProductComponent implements OnInit {

  constructor(private productService : ProductService) { }
  products : any
  ngOnInit(): void {
    this.getProduct()
  }
  getProduct() {
    let product: any;
    this.productService.GetRecentProduct().subscribe((res) => {
      product = res.body;
      this.products = product.data;
    });
  }
}
