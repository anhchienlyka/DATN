import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Product } from 'src/app/model/product.model';
import { NotificationService } from 'src/app/notification/notification.service';

@Component({
  selector: 'app-product-in-home',
  templateUrl: './product-in-home.component.html',
  styleUrls: ['./product-in-home.component.css']
})
export class ProductInHomeComponent implements OnInit {

  coutProduct:number=0;
  sanitizer: DomSanitizer;
  constructor(
    domSanitizer: DomSanitizer,
    private notifyService : NotificationService
    ) {

      this.sanitizer = domSanitizer;
     }

    
  @Input() product!: Product
  ngOnInit(): void {
  }
  showToasterWarning(){
    this.notifyService.showWarning("Số lượng hàng không đủ", "Thông báo")
}


  addToCart(product: Product){

  }
}
