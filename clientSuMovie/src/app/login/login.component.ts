import { Component, OnInit } from '@angular/core';
import {MoviesService} from '../movies.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private moviesService: MoviesService, private toastr: ToastrService) { }

  username: string;
  password: string;

  ngOnInit() {
  }

  login(){
      console.log(this.username);
      this.moviesService.logIn(this.username, this.password).subscribe(data =>{

        if(data!==undefined&&data!==null){
          this.toastr.success('Logowanie się powiodło! :)', 'Logowanie');
          localStorage.setItem("UserId", data['id']);
        }
        else
        this.toastr.error('Logowanie się nie powiodło! ):', 'Logowanie');
      })
  }

}
