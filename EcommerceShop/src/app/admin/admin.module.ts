import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { ListCategoryComponent } from './category-components/list-category/list-category.component';
import { CreateCategoryComponent } from './category-components/create-category/create-category.component';
import { UpdateCategoryComponent } from './category-components/update-category/update-category.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    AdminHomeComponent,
    AdminLayoutComponent,
    ListCategoryComponent,
    CreateCategoryComponent,
    UpdateCategoryComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
  ]
})
export class AdminModule { }
