import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/Services/product.service';
import { DataService } from 'src/app/share/data.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  cart: any;
  products: any;
  pageIndex: number = 1;
  pageSize: number = 2;
  totalPages: any;
  p: number = 1;
  productName!: string;
  categoryId!: string;
  constructor(
    private dataService: DataService,
    private router: ActivatedRoute,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.dataService.currentCart.subscribe(
      (editCart) => (this.cart = editCart)
    ); //<= Always get current value!
    //this.getAllProduct();
  
    this.router.params.subscribe(params=>{
      this.categoryId = params['id'];
      this.productName = params['name'];
      this.findProductsByName(this.productName);
      this.findProductsByCategoryId(this.categoryId)
    })
  }
  add2cart(item: any) {
    this.cart.products.push({ id: 1, data: {} });
    this.cart.cart = this.cart.cart + item;
    this.dataService.updateCart(this.cart);
  }

  findProductsByName(name: string) {
    let product:any
    this.productService.findProductsByName(name).subscribe((res) => {
      product = res.body;
      this.products= product.data
    });
  }
  findProductsByCategoryId(id: any) {
    let product:any
    this.productService.findProductsByCategoryId(id).subscribe((res) => {
      product = res.body;
      this.products= product.data
    });
  }

  getAllProduct() {
    let product: any;
    this.productService.getAllProducts().subscribe((res) => {
      product = res.body;
      this.products = product.data;
    });
  }
}
