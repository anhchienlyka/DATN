import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/category.service';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  categories: any;
  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this. getListCategory();
    console.log("asdasdasd",this.categories)
  }


  getListCategory()
  {
     this.categoryService.getCategories().subscribe(res=>{
      this.categories = res
    })
  }
}
