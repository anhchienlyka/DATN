import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/model/user.model';
import { NotificationService } from 'src/app/notification/notification.service';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  userData: any;

  constructor(
    private accountService: AccountService,
    private route: Router,
    private notificationSevice: NotificationService,
    private  fb: FormBuilder
  ) { 
    this.registerForm = fb.group({
      fullName: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      userName: ['', Validators.required],
      password: ['', Validators.required],
      address: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
    })
  }
  ngOnInit(): void {
  }
  onSubmit(){
    let formData = this.registerForm.value;
    //Set default value for register
    formData.roles = 2;
    this.accountService.register(formData).subscribe(res => {
      const response = JSON.parse(res);
      if(response.code==1)
     {
       this.notificationSevice.showSuccess("Đăng ký thành công","Thông báo");
       this.route.navigateByUrl('/login');
     }
     else{
      //  this.route.navigateByUrl('/register');
       this.notificationSevice.showError("False",response.message);
     }
    });
  }

}
