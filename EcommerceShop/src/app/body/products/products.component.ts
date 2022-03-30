import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/share/data.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(private dataService:DataService) { }
  selectedMessage:any;

  ngOnInit(): void {
   
    this.dataService.currentMessage.subscribe(message => (this.selectedMessage= message)); //<= Always get current value!
  }
  add2cart(item : any)
  {
    this.selectedMessage++;
    this.dataService.changeMessage(this.selectedMessage);
  }
}
