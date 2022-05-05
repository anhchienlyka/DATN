import { Component, OnInit } from '@angular/core';
import { Cart } from 'src/app/body/cart/cart.component';
import { Login } from 'src/app/body/login/login.component';
import { User } from 'src/app/model/user.model';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  currentUser: User;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser()
  {
   this.currentUser = this.accountService.getCurrentUser();
  }
  logout(){
    this.accountService.logout();
    Login.callBack.emit();
    Cart.callBack.emit();
  }
}
