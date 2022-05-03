import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { CartComponent } from './body/cart/cart.component';
import { CheckoutComponent } from './body/checkout/checkout.component';
import { ContactusComponent } from './body/contactus/contactus.component';
import { HomeComponent } from './body/home/home.component';
import { LoginComponent } from './body/login/login.component';
import { MyaccountComponent } from './body/myaccount/myaccount.component';
import { ProductDetailComponent } from './body/product-detail/product-detail.component';
import { ProductsComponent } from './body/products/products.component';
import { RegisterComponent } from './body/register/register.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'admin',component:AdminComponent},
  { path: 'products', component: ProductsComponent },
  { path: 'product-detail', component: ProductDetailComponent },
  { path: 'cart',component:CartComponent},
  { path: 'my-account',component:MyaccountComponent},
  { path: 'checkout',component:CheckoutComponent},
  { path: 'login',component:LoginComponent},
  { path: 'register',component:RegisterComponent},
  { path: 'contact',component:ContactusComponent},
  { path: 'GetProductByName/:name',component: ProductsComponent},
  { path: 'GetProductByCategoryId/:id',component: ProductsComponent},
  { path: 'detail/:id',component: ProductDetailComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
