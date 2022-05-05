import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { CreateCategoryComponent } from './admin/category-components/create-category/create-category.component';
import { ListCategoryComponent } from './admin/category-components/list-category/list-category.component';
import { UpdateCategoryComponent } from './admin/category-components/update-category/update-category.component';
import { CartComponent } from './body/cart/cart.component';
import { CheckoutComponent } from './body/checkout/checkout.component';
import { CompletedComponent } from './body/completed/completed.component';
import { ContactusComponent } from './body/contactus/contactus.component';
import { HomeComponent } from './body/home/home.component';
import { LoginComponent } from './body/login/login.component';
import { MyaccountComponent } from './body/myaccount/myaccount.component';
import { ProductDetailComponent } from './body/product-detail/product-detail.component';
import { ProductsComponent } from './body/products/products.component';
import { RegisterComponent } from './body/register/register.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';

const routes: Routes = [
  // { path: '', redirectTo: '/home', component: UserLayoutComponent, pathMatch: 'full', children:[
    { path: '', component: UserLayoutComponent, children:[
      { path: 'home', component: HomeComponent},
      { path: 'products', component: ProductsComponent},
      { path: 'product-detail', component: ProductDetailComponent},
      { path: 'cart',component:CartComponent},
      { path: 'my-account',component: MyaccountComponent},
      { path: 'cart/checkout',component: CheckoutComponent},
      { path: 'login',component: LoginComponent},
      { path: 'register',component: RegisterComponent},
      { path: 'contact',component: ContactusComponent},
      { path: 'GetProductByName/:name',component: ProductsComponent},
      { path: 'GetProductByCategoryId/:id',component: ProductsComponent},
      { path: 'detail/:id',component: ProductDetailComponent},
      {path:'completed',component:CompletedComponent}
  ] },
  { path: 'admin',component: AdminLayoutComponent, children: [
    {path: 'category', children: [
      {path: '', component: ListCategoryComponent},
      {path: 'create', component: CreateCategoryComponent},
      {path: 'update/:id', component: UpdateCategoryComponent},
    ]}
  ]},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
