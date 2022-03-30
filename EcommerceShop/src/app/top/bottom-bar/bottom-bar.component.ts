import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/share/data.service';

@Component({
  selector: 'app-bottom-bar',
  templateUrl: './bottom-bar.component.html',
  styleUrls: ['./bottom-bar.component.css']
})
export class BottomBarComponent implements OnInit {

  constructor(private dataService:DataService) { }
  selectedMessage:any;
  //Set value in component 1

  ngOnInit(): void {

    this.dataService.changeMessage("1");
    this.dataService.currentMessage.subscribe(message => (this.selectedMessage= message)); //<= Always get current value!
  }

}
