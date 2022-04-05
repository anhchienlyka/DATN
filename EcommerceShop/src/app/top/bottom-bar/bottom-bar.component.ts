import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/share/data.service';

@Component({
  selector: 'app-bottom-bar',
  templateUrl: './bottom-bar.component.html',
  styleUrls: ['./bottom-bar.component.css']
})
export class BottomBarComponent implements OnInit {

  constructor(private dataService:DataService,private router: Router) { }
  //Set value in component 1
  cart:any;
  playerName!: string;
  

  ngOnInit(): void {

    // this.dataService.updateCart("1")
    this.dataService.currentCart.subscribe(editCart => (this.cart= editCart));
  }
  onSubmit(){
    this.router.navigateByUrl(`GetProductByName/${this.playerName}`);
  }
}
