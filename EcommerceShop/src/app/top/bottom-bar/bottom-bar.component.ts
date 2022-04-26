import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Cart } from 'src/app/body/cart/cart.component';
import { CartService } from 'src/app/Services/cart.service';
import { DataService } from 'src/app/share/data.service';

@Component({
  selector: 'app-bottom-bar',
  templateUrl: './bottom-bar.component.html',
  styleUrls: ['./bottom-bar.component.css']
})
export class BottomBarComponent implements OnInit {

  constructor(private router: Router,private cartService: CartService) { }
  //Set value in component 1
  cart:any;
  playerName!: string;
  numberOfProductInCart: number = 0;


  ngOnInit(): void {
  this.getNumberOfProductInCart();
  Cart.callBack.subscribe(() => this.getNumberOfProductInCart());
  }

  onSubmit(){
    this.router.navigateByUrl(`GetProductByName/${this.playerName}`);
  }
  getNumberOfProductInCart(){
    var products = this.cartService.getProductInCart();
    if(products!=null){
      let sum = 0;
      products.forEach(product => {
         sum += product.quantity;
      });
      this.numberOfProductInCart = sum;
    }else{
      this.numberOfProductInCart = 0;
    }
    
  }
}
