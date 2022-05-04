import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/Services/category.service';
declare var $: any;  

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})
export class ListCategoryComponent implements OnInit {

  categories: any;

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategory();
  //   $(document).ready(() => {  
  //     console.log($('#myTable'));
  // }); 

  $(document).ready( function () {
    // $('#myTable').DataTable();
    console.log($('#myTable'));
} );
  }

  getCategory(){
    this.categoryService.getCategories().subscribe(res=>{
      console.log(res);
    })
  }

}
