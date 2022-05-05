import { Injectable } from '@angular/core';
import { ProductOrder } from '../model/cart.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  public cartItemList : any=[]
  constructor() { }

  addToCart(productOrder: ProductOrder){
    var listProductInCart = this.getProductInCart();
    //if wallme-cart in local storage is empty
    if(listProductInCart==null){
      listProductInCart = [];
      listProductInCart.push(productOrder);
      localStorage.setItem('wallme-cart',JSON.stringify(listProductInCart));
      return;
    }
    //If add a item already exist in wallme-cart, then add quantity 1
    var productExistInCart = listProductInCart.find(({productId})=> productId === productOrder.productId);
    if(!productExistInCart){
      listProductInCart.push(productOrder);
      localStorage.setItem('wallme-cart',JSON.stringify(listProductInCart));
      return;
    }
    //If add a new item not exist in wallme-cart
      productExistInCart.quantity += productOrder.quantity;
      localStorage.setItem('wallme-cart',JSON.stringify(listProductInCart));
  }

  getProductInCart(){
    let data: ProductOrder[] = JSON.parse(localStorage.getItem('wallme-cart'));
    return data;
  }
  getPriceInCart()
  {
    let data: ProductOrder[] = JSON.parse(localStorage.getItem('priceincart'));
    return data;
  }
  setPriceInCart(price : number)
  {

    localStorage.setItem('priceincart',JSON.stringify(price));
  }
  calculateTotalPrice(){
    var productsOrder = this.getProductInCart();
    let totalPrice = 0;
    productsOrder.forEach(product => {
      totalPrice += product.price*product.quantity*(100-product.sale)/100;
    });
    return totalPrice;
  }

  updateCart(productOrder: ProductOrder){
    var listProductInCart = this.getProductInCart();
    var productExistInCart = listProductInCart.find(({productId})=> productId === productOrder.productId);
    //check if quantity = 0, remove from cart
    if(productOrder.quantity == 0){
      listProductInCart = listProductInCart.filter(product=>product.productId !== productOrder.productId);
      localStorage.setItem('wallme-cart',JSON.stringify(listProductInCart));
    }
    productExistInCart.quantity = productOrder.quantity;
    localStorage.setItem('wallme-cart',JSON.stringify(listProductInCart));

  }


  removeCartItem(product:any)
  {

    this.cartItemList = this.getProductInCart();
    var productExistInCart = this.cartItemList .find(({productId})=> productId === product.productId);
    this.cartItemList.map((a:any, index:any)=>{
      if(productExistInCart.productId=== a.productId){
        this.cartItemList.splice(index,1);
      }
    })
    localStorage.setItem('wallme-cart',JSON.stringify(this.cartItemList));
  }
}
