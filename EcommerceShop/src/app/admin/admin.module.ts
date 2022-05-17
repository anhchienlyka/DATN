import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { RouterModule } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { CategoryComponent } from './category/category.component';
import { OrderComponent } from './order/order.component';
import { CommentComponent } from './comment/comment.component';
import { StatisticalComponent } from './statistical/statistical.component';
import { SalecodeComponent } from './salecode/salecode.component';
import { CustomerComponent } from './customer/customer.component';
import { PaymentComponent } from './payment/payment.component';
import { ProductCreateComponent } from './product/product-create/product-create.component';
import { ProductUpdateComponent } from './product/product-update/product-update.component';
import { CategoryCreateComponent } from './category/category-create/category-create.component';
import { CategoryUpdateComponent } from './category/category-update/category-update.component';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    ProductComponent,
    CategoryComponent,
    OrderComponent,
    CommentComponent,
    StatisticalComponent,
    SalecodeComponent,
    CustomerComponent,
    PaymentComponent,
    ProductCreateComponent,
    ProductUpdateComponent,
    CategoryCreateComponent,
    CategoryUpdateComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
  ]
})
export class AdminModule { }
