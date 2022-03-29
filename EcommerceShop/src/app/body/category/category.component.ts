import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  constructor(private category: CategoryService) {}
  categories: any;
  ngOnInit(): void {}


  getListCategory()
  {
    this.category.getCategories().subscribe(res=>{
      this.categories = res;
    })
  }
}
