import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/model/user.model';
import { NotificationService } from 'src/app/notification/notification.service';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  userData:any;
  
  constructor(
    private accountService: AccountService,
    private route: Router,
    private notificationSevice: NotificationService,
    private  fb: FormBuilder
  ) {

    this.loginForm = fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    })

  }

  ngOnInit(): void {
    
  }

  onSubmitLogin() {
    
    let model: Login = this.loginForm.value;
    this.accountService.login(model).subscribe(res => {
      const obj = JSON.parse(res);
     if(obj.code==1)
     {
       this.userData = obj.data
       localStorage.setItem('userInfor',JSON.stringify(this.userData));
       Login.callBack.emit();
       if(this.userData.roles==2)
       {
        this.route.navigateByUrl('/home');
        this.notificationSevice.showSuccess("Đăng nhập thành công","Thông báo");
       }
       else if(this.userData.roles==1){
        this.route.navigateByUrl('/admin');
        this.notificationSevice.showSuccess("Đăng nhập thành công","Thông báo");
       }
     
     }
     else{
       this.route.navigateByUrl('/login');
       this.notificationSevice.showError("Đăng nhập không thành công","Thông báo");
     }
    });
    

  }



}
export class Login {
  static callBack = new EventEmitter();
}
