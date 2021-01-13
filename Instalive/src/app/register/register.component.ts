import { Component,  OnInit,Input, Output, EventEmitter } from '@angular/core';
import { AccountService } from '../_services/account.service';
//import { EventEmitter } from 'events';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 
  @Output() cancelRegister = new EventEmitter();
  model : any = {};
  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe(response =>{
      console.log(response);
      this.cancle();
    }, error => {
      console.log(error);
    })

  }
  cancle(){
    this.cancelRegister.emit(false);
  }

}